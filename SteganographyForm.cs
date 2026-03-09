using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace EvilCorp
{
    /// <summary>
    /// EvilHide — WinForms replica of steganography.html.
    /// Implements n-bit LSB image steganography: hide an image inside a cover image,
    /// and extract it back, using a configurable binary mask (e.g. 11111100 = 2-bit LSB).
    /// </summary>
    public partial class SteganographyForm : Form
    {
        // ── Palette (matches HTML :root vars) ──────────────────────────────────
        private static readonly Color BgColor = Color.FromArgb(15, 23, 42);   // #0f172a
        private static readonly Color CardBg = Color.FromArgb(30, 41, 59);   // glassmorphism card
        private static readonly Color CardBorder = Color.FromArgb(255, 255, 255, 26); // rgba(255,255,255,0.1)
        private static readonly Color AccentBlue = Color.FromArgb(45, 126, 247);   // #2d7ef7
        private static readonly Color AccentBlueDark = Color.FromArgb(27, 99, 204);   // #1b63cc
        private static readonly Color AccentGreen = Color.FromArgb(0, 255, 127);   // #00ff7f
        private static readonly Color TextPrimary = Color.FromArgb(248, 250, 252);  // #f8fafc
        private static readonly Color TextMuted = Color.FromArgb(148, 163, 184);  // #94a3b8
        private static readonly Color InputBg = Color.FromArgb(0, 0, 0, 102); // rgba(0,0,0,0.4) approx
        private static readonly Color BitViewerBg = Color.FromArgb(0, 0, 0);

        // ── State ──────────────────────────────────────────────────────────────
        private Bitmap? _coverBmp = null;
        private Bitmap? _secretBmp = null;
        private Bitmap? _composite = null;
        private Bitmap? _targetBmp = null;
        private Bitmap? _extracted = null;

        public SteganographyForm()
        {
            InitializeComponent();
            ApplyTheme();
            this.Load += (s, e) => AdjustLayout();
            this.Shown += (s, e) => AdjustLayout();
            this.Resize += (s, e) => AdjustLayout();
            splitter.SplitterMoved += (s, e) => AdjustLayout();
        }

        // ══════════════════════════════════════════════════════════════════════
        // THEME / STYLE
        // ══════════════════════════════════════════════════════════════════════
        private void ApplyTheme()
        {
            this.BackColor = BgColor;

            // Root
            pnlRoot.BackColor = BgColor;

            // Title
            lblTitle.ForeColor = Color.White;
            lblTitle.Font = new Font("Segoe UI", 18f, FontStyle.Bold);
            lblTitle.BackColor = AccentBlue;

            // ── Splitter ──────────────────────────────────────────────────────
            splitter.BackColor = Color.FromArgb(24, 36, 64);   // dark divider
            splitter.Panel1.BackColor = BgColor;
            splitter.Panel2.BackColor = BgColor;

            // ── Hide panel ────────────────────────────────────────────────────
            StyleCard(pnlHide);
            StylePanelTitle(lblHideTitle, "Encacher un secret");
            StyleInputLabel(lblCoverLabel);
            StyleInputLabel(lblSecretLabel);
            StyleInputLabel(lblMaskHideLabel);
            StyleFileLabel(lblCoverFileName);
            StyleFileLabel(lblSecretFileName);
            StyleSecondaryButton(btnCoverFile);
            StyleSecondaryButton(btnSecretFile);
            StyleTextBox(txtMaskHide);
            StyleActionButton(btnFuse);
            StylePreviewPanel(pnlCoverPreview);
            StylePreviewPanel(pnlSecretPreview);
            StylePreviewPanel(pnlCompositePreview);
            StylePreviewTitle(lblCoverPreviewTitle);
            StylePreviewTitle(lblSecretPreviewTitle);
            StylePreviewTitle(lblCompositeTitle);
            lblCoverPreviewTitle.Text = "Porteur (Cover)";
            lblSecretPreviewTitle.Text = "Secret";
            lblCompositeTitle.Text = "Composite";
            picCover.BackColor = Color.Black;
            picSecret.BackColor = Color.Black;
            picComposite.BackColor = Color.Black;
            StyleSmallButton(btnDownload);
            StyleBitViewer(rtbHideBits);

            // ── Extract panel ─────────────────────────────────────────────────
            StyleCard(pnlExtract);
            StylePanelTitle(lblExtractTitle, "Extraire un secret");
            StyleInputLabel(lblTargetLabel);
            StyleInputLabel(lblMaskExtractLabel);
            StyleFileLabel(lblTargetFileName);
            StyleSecondaryButton(btnTargetFile);
            StyleTextBox(txtMaskExtract);
            StyleActionButton(btnDecode);
            StylePreviewPanel(pnlExtractPreview);
            StylePreviewTitle(lblExtractedTitle);
            picExtracted.BackColor = Color.Black;
            StyleBitViewer(rtbExtractBits);
        }

        private static void StyleCard(Panel pnl)
        {
            pnl.BackColor = CardBg;
            pnl.BorderStyle = BorderStyle.FixedSingle;
        }

        private static void StylePanelTitle(Label lbl, string text)
        {
            lbl.Text = text;
            lbl.ForeColor = AccentBlue;
            lbl.Font = new Font("Segoe UI", 12f, FontStyle.Bold);
        }

        private static void StyleInputLabel(Label lbl)
        {
            lbl.ForeColor = Color.White;
            lbl.Font = new Font("Segoe UI", 9.5f, FontStyle.Regular);
        }

        private static void StyleSecondaryButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(45, 55, 72);
            btn.ForeColor = Color.White;
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 1;
            btn.FlatAppearance.BorderColor = Color.FromArgb(74, 85, 104);
            btn.Cursor = Cursors.Hand;
        }

        private static void StyleFileLabel(Label lbl)
        {
            lbl.ForeColor = Color.FromArgb(100, 163, 230);
            lbl.Font = new Font("Segoe UI", 8.5f, FontStyle.Italic);
        }

        private static void StyleTextBox(TextBox tb)
        {
            tb.BackColor = Color.FromArgb(20, 28, 48);
            tb.ForeColor = TextPrimary;
            tb.BorderStyle = BorderStyle.FixedSingle;
        }

        private static void StyleActionButton(Button btn)
        {
            btn.BackColor = AccentBlue;
            btn.ForeColor = Color.White;
            btn.Font = new Font("Segoe UI", 11f, FontStyle.Bold);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = AccentBlueDark;
            btn.Cursor = Cursors.Hand;
            btn.MouseEnter += (s, e) => btn.BackColor = AccentBlueDark;
            btn.MouseLeave += (s, e) => btn.BackColor = AccentBlue;
        }

        private static void StyleSmallButton(Button btn)
        {
            btn.BackColor = Color.FromArgb(40, 80, 160);
            btn.ForeColor = TextPrimary;
            btn.Font = new Font("Segoe UI", 8f);
            btn.FlatStyle = FlatStyle.Flat;
            btn.FlatAppearance.BorderSize = 0;
            btn.Cursor = Cursors.Hand;
            btn.Text = "💾  Télécharger";
        }

        private static void StylePreviewPanel(Panel pnl)
        {
            pnl.BackColor = Color.FromArgb(40, 40, 40);
            pnl.BorderStyle = BorderStyle.FixedSingle;
        }

        private static void StylePreviewTitle(Label lbl)
        {
            lbl.ForeColor = Color.FromArgb(100, 116, 139); // #64748b
            lbl.Font = new Font("Segoe UI", 8.5f, FontStyle.Bold);
        }

        private static void StyleBitViewer(RichTextBox rtb)
        {
            rtb.BackColor = BitViewerBg;
            rtb.ForeColor = AccentGreen;
            rtb.Font = new Font("Cascadia Code", 9f);
        }

        // ══════════════════════════════════════════════════════════════════════
        // LAYOUT  — stretch controls to fill each splitter panel
        // ══════════════════════════════════════════════════════════════════════
        private void AdjustLayout()
        {
            // Left panel (Hide)
            int lw = Math.Max(100, splitter.Panel1.ClientSize.Width - 32);
            btnCoverFile.Width = lw;
            lblCoverFileName.Width = lw;
            btnSecretFile.Width = lw;
            lblSecretFileName.Width = lw;
            lblCoverLabel.Width = lw;
            lblSecretLabel.Width = lw;
            lblMaskHideLabel.Width = lw;
            txtMaskHide.Width = lw;
            btnFuse.Width = lw;
            pnlHidePreview.Width = lw;
            rtbHideBits.Width = lw;

            int third = Math.Max(40, (lw - 24) / 3);
            pnlCoverPreview.Width = third;
            pnlSecretPreview.Width = third;
            pnlCompositePreview.Width = lw - (third * 2) - 24;

            pnlSecretPreview.Left = third + 12;
            pnlCompositePreview.Left = (third * 2) + 24;

            // Right panel (Extract)
            int rw = Math.Max(100, splitter.Panel2.ClientSize.Width - 32);
            btnTargetFile.Width = rw;
            lblTargetFileName.Width = rw;
            lblTargetLabel.Width = rw;
            lblMaskExtractLabel.Width = rw;
            txtMaskExtract.Width = rw;
            btnDecode.Width = rw;
            pnlExtractPreview.Width = rw;
            rtbExtractBits.Width = rw;
        }

        // ══════════════════════════════════════════════════════════════════════
        // FILE PICKERS
        // ══════════════════════════════════════════════════════════════════════
        private void btnCoverFile_Click(object sender, EventArgs e)
        {
            if (dlgCover.ShowDialog() == DialogResult.OK)
            {
                _coverBmp?.Dispose();
                _coverBmp = new Bitmap(dlgCover.FileName);
                picCover.Image?.Dispose();
                picCover.Image = (Bitmap)_coverBmp.Clone();
                lblCoverFileName.Text = Path.GetFileName(dlgCover.FileName);
            }
        }

        private void btnSecretFile_Click(object? s, EventArgs e)
        {
            if (dlgSecret.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    _secretBmp = new Bitmap(dlgSecret.FileName);
                    lblSecretFileName.Text = Path.GetFileName(dlgSecret.FileName);
                    picSecret.Image = _secretBmp;
                    // LogHide("Secret image loaded."); // No LogHide method exists
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erreur image: " + ex.Message, "EvilHide",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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

        // ══════════════════════════════════════════════════════════════════════
        // LSB CORE LOGIC — mirrors JS getMaskInfo / processHide / processExtract
        // ══════════════════════════════════════════════════════════════════════

        /// <summary>
        /// Parses an 8-character binary mask string (e.g. "11111100")
        /// and returns:
        ///   mask        — the integer mask applied to cover pixels (clears LSBs)
        ///   numZeros    — how many LSB bits are used for encoding
        ///   shift       — how far to shift secret pixel bits (= 8 - numZeros)
        ///   extractMask — mask to isolate the hidden bits (= 0xFF >> shift)
        /// </summary>
        private static (int mask, int numZeros, int shift, int extractMask) GetMaskInfo(string maskStr)
        {
            // Validate: must be 8 binary chars
            maskStr = maskStr.Trim();
            if (maskStr.Length != 8)
                throw new ArgumentException("Le masque doit être 8 bits (ex: 11111100).");
            foreach (char c in maskStr)
                if (c != '0' && c != '1')
                    throw new ArgumentException("Le masque ne doit contenir que '0' et '1'.");

            int mask = Convert.ToInt32(maskStr, 2);   // e.g. 11111100 → 252
            int numZeros = maskStr.Split('0').Length - 1; // e.g. 2
            int shift = 8 - numZeros;                  // e.g. 6
            int extMask = 0xFF >> shift;                 // e.g. 0x03 (0000 0011)
            return (mask, numZeros, shift, extMask);
        }

        // ── HIDE (Fusionner) ───────────────────────────────────────────────
        private void btnFuse_Click(object sender, EventArgs e)
        {
            if (_coverBmp == null || _secretBmp == null)
            {
                MessageBox.Show("Sélectionnez les deux images !", "EvilHide",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            (int mask, int numZeros, int shift, int extractMask) info;
            try
            {
                info = GetMaskInfo(txtMaskHide.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Masque invalide",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnFuse.Enabled = false;
            btnFuse.Text = "Traitement...";
            Application.DoEvents();

            try
            {
                int w = _coverBmp.Width;
                int h = _coverBmp.Height;

                // Scale secret to cover dimensions (mirrors hCtx.drawImage(imgS,0,0,imgC.width,imgC.height))
                using var scaledSecret = new Bitmap(_secretBmp, new Size(w, h));

                // Work with 32bppArgb copies for fast pixel access
                var composite = new Bitmap(w, h, PixelFormat.Format32bppArgb);

                BitmapData coverData = null!;
                BitmapData secretData = null!;
                BitmapData compData = null!;

                try
                {
                    coverData = LockBmpReadOnly(_coverBmp, new Rectangle(0, 0, w, h));
                    secretData = LockBmpReadOnly(scaledSecret, new Rectangle(0, 0, w, h));
                    compData = LockBmpWrite(composite, new Rectangle(0, 0, w, h));

                    unsafe
                    {
                        byte* cPix = (byte*)coverData.Scan0;
                        byte* sPix = (byte*)secretData.Scan0;
                        byte* outPx = (byte*)compData.Scan0;

                        int stride = coverData.Stride;
                        int mask8 = info.mask;
                        int sh8 = info.shift;

                        for (int row = 0; row < h; row++)
                        {
                            int rowOff = row * stride;
                            for (int col = 0; col < w; col++)
                            {
                                int off = rowOff + col * 4;
                                for (int ch = 0; ch < 3; ch++)
                                {
                                    outPx[off + ch] = (byte)((cPix[off + ch] & mask8) | (sPix[off + ch] >> sh8));
                                }
                                outPx[off + 3] = 255;
                            }
                        }
                    }
                }
                finally
                {
                    if (coverData != null) UnlockBmp(_coverBmp, coverData);
                    if (secretData != null) UnlockBmp(scaledSecret, secretData);
                    if (compData != null) UnlockBmp(composite, compData);
                }

                _composite?.Dispose();
                _composite = composite;
                picComposite.Image = _composite;
                LogBits(rtbHideBits, _composite, w, h);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnFuse.Enabled = true;
                btnFuse.Text = "FUSIONNER LES IMAGES";
            }
        }

        // ── EXTRACT (Décoder) ──────────────────────────────────────────────
        private void btnDecode_Click(object sender, EventArgs e)
        {
            if (_targetBmp == null)
            {
                MessageBox.Show("Sélectionnez l'image à analyser !", "EvilHide",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            (int mask, int numZeros, int shift, int extractMask) info;
            try
            {
                info = GetMaskInfo(txtMaskExtract.Text.Trim());
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Masque invalide",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            btnDecode.Enabled = false;
            btnDecode.Text = "Décodage...";
            Application.DoEvents();

            try
            {
                int w = _targetBmp.Width;
                int h = _targetBmp.Height;

                var extracted = new Bitmap(w, h, PixelFormat.Format32bppArgb);
                BitmapData srcData = null!;
                BitmapData dstData = null!;

                try
                {
                    srcData = LockBmpReadOnly(_targetBmp, new Rectangle(0, 0, w, h));
                    dstData = LockBmpWrite(extracted, new Rectangle(0, 0, w, h));

                    unsafe
                    {
                        byte* src = (byte*)srcData.Scan0;
                        byte* dst = (byte*)dstData.Scan0;

                        int stride = srcData.Stride;
                        int extMask = info.extractMask;
                        int sh8 = info.shift;

                        for (int row = 0; row < h; row++)
                        {
                            int rowOff = row * stride;
                            for (int col = 0; col < w; col++)
                            {
                                int off = rowOff + col * 4;
                                for (int ch = 0; ch < 3; ch++)
                                {
                                    dst[off + ch] = (byte)((src[off + ch] & extMask) << sh8);
                                }
                                dst[off + 3] = 255;
                            }
                        }
                    }
                }
                finally
                {
                    if (srcData != null) UnlockBmp(_targetBmp, srcData);
                    if (dstData != null) UnlockBmp(extracted, dstData);
                }

                _extracted?.Dispose();
                _extracted = extracted;

                picExtracted.Image = _extracted;
                LogBits(rtbExtractBits, _extracted, w, h);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur: " + ex.Message, "Erreur",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                btnDecode.Enabled = true;
                btnDecode.Text = "DÉCODER LE SECRET";
            }
        }

        // ── DOWNLOAD ───────────────────────────────────────────────────────
        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (_composite == null)
            {
                MessageBox.Show("Aucun composite à sauvegarder.", "EvilHide",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (dlgSave.ShowDialog() == DialogResult.OK)
            {
                _composite.Save(dlgSave.FileName, ImageFormat.Png);
                MessageBox.Show($"Sauvegardé: {dlgSave.FileName}", "EvilHide",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // ══════════════════════════════════════════════════════════════════════
        // BIT LOG (mirrors logBits JS helper — shows first 25 pixels as binary)
        // ══════════════════════════════════════════════════════════════════════
        private static void LogBits(RichTextBox rtb, Bitmap bmp, int w, int h)
        {
            var sb = new StringBuilder();
            int pixCount = Math.Min(25, w * h);

            for (int i = 0; i < pixCount; i++)
            {
                int px = i % w;
                int py = i / w;
                Color c = bmp.GetPixel(px, py);
                string r = Convert.ToString(c.R, 2).PadLeft(8, '0');
                string g = Convert.ToString(c.G, 2).PadLeft(8, '0');
                string b = Convert.ToString(c.B, 2).PadLeft(8, '0');
                sb.AppendLine($"Pixel {i + 1,3}: R:{r} G:{g} B:{b}");
            }

            rtb.Text = sb.Length > 0 ? sb.ToString() : "Pas de données";
            rtb.SelectionStart = 0;
            rtb.ScrollToCaret();
        }

        // ══════════════════════════════════════════════════════════════════════
        // BITMAP LOCK HELPERS (unsafe fast pixel access)
        // ══════════════════════════════════════════════════════════════════════
        private static BitmapData LockBmpReadOnly(Bitmap bmp, Rectangle rect)
            => bmp.LockBits(rect, ImageLockMode.ReadOnly, PixelFormat.Format32bppArgb);

        private static BitmapData LockBmpWrite(Bitmap bmp, Rectangle rect)
            => bmp.LockBits(rect, ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

        private static void UnlockBmp(Bitmap bmp, BitmapData data)
            => bmp.UnlockBits(data);

    }

    /// <summary>
    /// Custom PictureBox that uses NearestNeighbor interpolation for pixelated rendering of small images.
    /// </summary>
    public class PixelBox : PictureBox
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            if (Image == null)
            {
                base.OnPaint(e);
                return;
            }

            var g = e.Graphics;
            g.InterpolationMode = InterpolationMode.NearestNeighbor;
            g.PixelOffsetMode = PixelOffsetMode.Half;

            // Calculate zoom logic manually to ensure pixel-perfect rendering
            float ratio = Math.Min((float)this.ClientSize.Width / Image.Width, (float)this.ClientSize.Height / Image.Height);
            int w = (int)(Image.Width * ratio);
            int h = (int)(Image.Height * ratio);
            int x = (this.ClientSize.Width - w) / 2;
            int y = (this.ClientSize.Height - h) / 2;

            g.DrawImage(Image, new Rectangle(x, y, w, h));
        }
    }
}
