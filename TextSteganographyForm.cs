using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;
using System.Collections.Generic;

namespace EvilCorp
{
    public partial class TextSteganographyForm : Form
    {
        private static readonly Color BgColor = Color.FromArgb(15, 23, 42);
        private static readonly Color CardBg = Color.FromArgb(30, 41, 59);
        private static readonly Color AccentBlue = Color.FromArgb(45, 126, 247);
        private static readonly Color TextPrimary = Color.FromArgb(248, 250, 252);

        private Bitmap? _coverBmp = null;
        private Bitmap? _composite = null;
        private Bitmap? _targetBmp = null;

        public TextSteganographyForm()
        {
            InitializeComponent();
            ApplyTheme();
            this.Shown += (s, e) => AdjustLayout();
            this.Resize += (s, e) => AdjustLayout();
            AdjustLayout(); // Force initial layout
        }

        private void ApplyTheme()
        {
            this.BackColor = BgColor;
            pnlRoot.BackColor = BgColor;
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 18f, FontStyle.Bold);
            lblTitle.BackColor = AccentBlue;

            splitter.BackColor = Color.FromArgb(24, 36, 64);
            splitter.Panel1.BackColor = BgColor;
            splitter.Panel2.BackColor = BgColor;

            StylePanel(pnlHide, lblHideTitle);
            StyleLabel(lblCoverLabel);
            StyleLabel(lblTextLabel);
            StyleLabel(lblMaskHideLabel);
            StyleTextBox(txtMaskHide);
            StyleRichTextBox(txtSecretText);
            StyleActionButton(btnFuse);
            StylePreviewPanel(pnlCoverPreview, lblCoverPreviewTitle);
            StylePreviewPanel(pnlCompositePreview, lblCompositeTitle);
            btnDownload.BackColor = AccentBlue;
            btnDownload.ForeColor = Color.White;

            StylePanel(pnlExtract, lblExtractTitle);
            StyleLabel(lblTargetLabel);
            StyleLabel(lblMaskExtractLabel);
            StyleTextBox(txtMaskExtract);
            StyleActionButton(btnDecode);
            StyleLabel(lblExtractedTextLabel);
            StyleRichTextBox(txtExtractedText);
        }

        private void StylePanel(Panel p, Label title)
        {
            p.BackColor = CardBg;
            p.BorderStyle = BorderStyle.FixedSingle;
            title.ForeColor = AccentBlue;
            title.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
        }

        private void StyleLabel(Label l)
        {
            l.ForeColor = Color.White;
            l.Font = new Font("Segoe UI", 9f);
        }

        private void StyleTextBox(TextBox t)
        {
            t.BackColor = Color.FromArgb(10, 10, 10);
            t.ForeColor = Color.White;
            t.BorderStyle = BorderStyle.FixedSingle;
        }

        private void StyleRichTextBox(RichTextBox r)
        {
            r.BackColor = Color.FromArgb(10, 10, 10);
            r.ForeColor = Color.FromArgb(250, 250, 250); // Explicit near-white
            r.Font = new Font("Segoe UI", 10f);
        }

        private void StyleActionButton(Button b)
        {
            b.BackColor = AccentBlue;
            b.ForeColor = Color.White;
            b.FlatStyle = FlatStyle.Flat;
            b.FlatAppearance.BorderSize = 0;
            b.Font = new Font("Segoe UI", 10f, FontStyle.Bold);
        }

        private void StylePreviewPanel(Panel p, Label l)
        {
            p.BackColor = Color.FromArgb(40, 40, 40);
            p.BorderStyle = BorderStyle.FixedSingle;
            l.ForeColor = Color.White;
            l.Font = new Font("Segoe UI", 8f, FontStyle.Bold);
        }

        private void AdjustLayout()
        {
            if (splitter == null || splitter.Panel1 == null || splitter.Panel2 == null) return;

            int lw = Math.Max(100, splitter.Panel1.ClientSize.Width - 32);
            btnCoverFile.Width = lw;
            lblCoverFileName.Width = lw;
            txtSecretText.Width = lw;
            txtMaskHide.Width = lw;
            btnFuse.Width = lw;
            pnlHidePreview.Width = lw;

            // Resize sub-previews
            int half = (lw - 10) / 2;
            pnlCoverPreview.Width = half;
            pnlCompositePreview.Width = lw - half - 10;
            pnlCompositePreview.Left = half + 10;

            int rw = Math.Max(100, splitter.Panel2.ClientSize.Width - 32);
            btnTargetFile.Width = rw;
            lblTargetFileName.Width = rw;
            txtMaskExtract.Width = rw;
            btnDecode.Width = rw;
            txtExtractedText.Width = rw;
        }

        private void btnCoverFile_Click(object sender, EventArgs e)
        {
            if (dlgCover.ShowDialog() == DialogResult.OK)
            {
                _coverBmp?.Dispose();
                _coverBmp = new Bitmap(dlgCover.FileName);
                lblCoverFileName.Text = Path.GetFileName(dlgCover.FileName);
                picCover.Image?.Dispose(); // Clear old image
                picCover.Image = _coverBmp;
            }
        }

        private void btnTargetFile_Click(object sender, EventArgs e)
        {
            if (dlgTarget.ShowDialog() == DialogResult.OK)
            {
                _targetBmp?.Dispose();
                _targetBmp = new Bitmap(dlgTarget.FileName);
                lblTargetFileName.Text = Path.GetFileName(dlgTarget.FileName);
            }
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (_composite != null && dlgSave.ShowDialog() == DialogResult.OK)
            {
                _composite.Save(dlgSave.FileName, ImageFormat.Png);
                MessageBox.Show("Sauvegardé !", "EvilHide");
            }
        }

        // ── CORE ALGORITHM ──

        private void btnFuse_Click(object sender, EventArgs e)
        {
            if (_coverBmp == null || string.IsNullOrEmpty(txtSecretText.Text))
            {
                MessageBox.Show("Image and text required.", "EvilHide");
                return;
            }

            int bitsPerPixel;
            if (!int.TryParse(txtMaskHide.Text, out bitsPerPixel) || bitsPerPixel < 1 || bitsPerPixel > 8)
            {
                MessageBox.Show("Bits per pixel must be 1-8.", "EvilHide");
                return;
            }

            try
            {
                byte[] textBytes = Encoding.UTF8.GetBytes(txtSecretText.Text);
                byte[] lengthBytes = BitConverter.GetBytes(textBytes.Length);

                byte[] fullPayload = new byte[lengthBytes.Length + textBytes.Length];
                Buffer.BlockCopy(lengthBytes, 0, fullPayload, 0, lengthBytes.Length);
                Buffer.BlockCopy(textBytes, 0, fullPayload, lengthBytes.Length, textBytes.Length);

                var composite = new Bitmap(_coverBmp);
                if (HideData(composite, fullPayload, bitsPerPixel))
                {
                    _composite?.Dispose();
                    _composite = composite;
                    picComposite.Image = _composite;
                    MessageBox.Show("Texte caché avec succès !", "EvilHide");
                }
                else
                {
                    composite.Dispose();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur de traitement: " + ex.Message, "EvilHide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDecode_Click(object sender, EventArgs e)
        {
            if (_targetBmp == null)
            {
                MessageBox.Show("Select composite image.", "EvilHide");
                return;
            }

            int bitsPerPixel;
            if (!int.TryParse(txtMaskExtract.Text, out bitsPerPixel) || bitsPerPixel < 1 || bitsPerPixel > 8)
            {
                MessageBox.Show("Bits per pixel must be 1-8.", "EvilHide");
                return;
            }

            try
            {
                byte[] extracted = ExtractData(_targetBmp, bitsPerPixel);
                if (extracted != null && extracted.Length >= 4)
                {
                    int len = BitConverter.ToInt32(extracted, 0);
                    if (len > 0 && len <= extracted.Length - 4)
                    {
                        string result = Encoding.UTF8.GetString(extracted, 4, len);
                        txtExtractedText.Text = result;
                        MessageBox.Show("Texte extrait !", "EvilHide");
                    }
                    else
                    {
                        MessageBox.Show("Aucun texte valide n'a été trouvé avec ce masque.", "EvilHide", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'extraction: " + ex.Message, "EvilHide", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private unsafe bool HideData(Bitmap bmp, byte[] data, int bitsPerPixel)
        {
            long totalBits = data.Length * 8L;
            long capacity = (long)bmp.Width * bmp.Height * 3 * bitsPerPixel; // RGB channels

            if (totalBits > capacity)
            {
                MessageBox.Show($"Data too large. Required: {totalBits} bits, Capacity: {capacity} bits.", "EvilHide");
                return false;
            }

            BitmapData bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
            try
            {
                byte* ptr = (byte*)bd.Scan0;

                int byteIdx = 0;
                int bitIdx = 0;
                int mask = (0xFF << bitsPerPixel) & 0xFF;

                for (int y = 0; y < bmp.Height; y++)
                {
                    byte* row = ptr + (y * bd.Stride);
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        for (int c = 0; c < 3; c++) // B, G, R
                        {
                            if (byteIdx >= data.Length) return true;

                            int val = 0;
                            for (int b = 0; b < bitsPerPixel; b++)
                            {
                                if (byteIdx >= data.Length) break;
                                int bit = (data[byteIdx] >> (7 - bitIdx)) & 1;
                                val |= (bit << (bitsPerPixel - 1 - b));
                                bitIdx++;
                                if (bitIdx >= 8) { bitIdx = 0; byteIdx++; }
                            }

                            row[x * 3 + c] = (byte)((row[x * 3 + c] & mask) | val);
                        }
                    }
                }
                return true;
            }
            finally
            {
                bmp.UnlockBits(bd);
            }
        }

        private unsafe byte[] ExtractData(Bitmap bmp, int bitsPerPixel)
        {
            BitmapData bd = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadOnly, PixelFormat.Format24bppRgb);
            try
            {
                byte* ptr = (byte*)bd.Scan0;

                List<byte> data = new List<byte>();
                byte currentByte = 0;
                int bitIdx = 0;
                int extractMask = (1 << bitsPerPixel) - 1;

                // First 4 bytes (32 bits) are length
                int expectedLen = -1;

                for (int y = 0; y < bmp.Height; y++)
                {
                    byte* row = ptr + (y * bd.Stride);
                    for (int x = 0; x < bmp.Width; x++)
                    {
                        for (int c = 0; c < 3; c++)
                        {
                            int val = row[x * 3 + c] & extractMask;
                            for (int b = 0; b < bitsPerPixel; b++)
                            {
                                int bit = (val >> (bitsPerPixel - 1 - b)) & 1;
                                currentByte = (byte)((currentByte << 1) | bit);
                                bitIdx++;
                                if (bitIdx >= 8)
                                {
                                    data.Add(currentByte);
                                    currentByte = 0;
                                    bitIdx = 0;

                                    if (expectedLen == -1 && data.Count == 4)
                                    {
                                        expectedLen = BitConverter.ToInt32(data.ToArray(), 0);
                                        if (expectedLen <= 0 || expectedLen > 10_000_000) return data.ToArray();
                                    }
                                    if (expectedLen != -1 && data.Count >= expectedLen + 4)
                                    {
                                        return data.ToArray();
                                    }
                                }
                            }
                        }
                    }
                }
                return data.ToArray();
            }
            finally
            {
                bmp.UnlockBits(bd);
            }
        }
    }
}
