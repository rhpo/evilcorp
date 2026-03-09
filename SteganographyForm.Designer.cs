namespace EvilCorp
{
    partial class SteganographyForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        private void InitializeComponent()
        {
            // ── Root ───────────────────────────────────────────────────
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitter = new System.Windows.Forms.SplitContainer();

            // ── HIDE panel controls ────────────────────────────────────
            this.pnlHide = new System.Windows.Forms.Panel();
            this.lblHideTitle = new System.Windows.Forms.Label();
            this.lblCoverLabel = new System.Windows.Forms.Label();
            this.btnCoverFile = new System.Windows.Forms.Button();
            this.lblCoverFileName = new System.Windows.Forms.Label();
            this.lblSecretLabel = new System.Windows.Forms.Label();
            this.btnSecretFile = new System.Windows.Forms.Button();
            this.lblSecretFileName = new System.Windows.Forms.Label();
            this.lblMaskHideLabel = new System.Windows.Forms.Label();
            this.txtMaskHide = new System.Windows.Forms.TextBox();
            this.btnFuse = new System.Windows.Forms.Button();
            this.pnlHidePreview = new System.Windows.Forms.Panel();
            this.pnlCoverPreview = new System.Windows.Forms.Panel();
            this.lblCoverPreviewTitle = new System.Windows.Forms.Label();
            this.picCover = new EvilCorp.PixelBox();
            this.pnlSecretPreview = new System.Windows.Forms.Panel();
            this.lblSecretPreviewTitle = new System.Windows.Forms.Label();
            this.picSecret = new EvilCorp.PixelBox();
            this.pnlCompositePreview = new System.Windows.Forms.Panel();
            this.lblCompositeTitle = new System.Windows.Forms.Label();
            this.picComposite = new EvilCorp.PixelBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.rtbHideBits = new System.Windows.Forms.RichTextBox();

            // ── EXTRACT panel controls ─────────────────────────────────
            this.pnlExtract = new System.Windows.Forms.Panel();
            this.lblExtractTitle = new System.Windows.Forms.Label();
            this.lblTargetLabel = new System.Windows.Forms.Label();
            this.btnTargetFile = new System.Windows.Forms.Button();
            this.lblTargetFileName = new System.Windows.Forms.Label();
            this.lblMaskExtractLabel = new System.Windows.Forms.Label();
            this.txtMaskExtract = new System.Windows.Forms.TextBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.pnlExtractPreview = new System.Windows.Forms.Panel();
            this.lblExtractedTitle = new System.Windows.Forms.Label();
            this.picExtracted = new EvilCorp.PixelBox();
            this.rtbExtractBits = new System.Windows.Forms.RichTextBox();

            // ── Dialogs ───────────────────────────────────────────────
            this.dlgCover = new System.Windows.Forms.OpenFileDialog();
            this.dlgSecret = new System.Windows.Forms.OpenFileDialog();
            this.dlgTarget = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();

            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.SuspendLayout();

            // ══════════════════════════════════════════════════════════
            // FORM
            // ══════════════════════════════════════════════════════════
            this.AutoScaleDimensions = new System.Drawing.SizeF(96F, 96F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(1300, 860);
            this.MinimumSize = new System.Drawing.Size(900, 700);
            this.Name = "SteganographyForm";
            this.Text = "EvilHide — Image Steganography";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // ══════════════════════════════════════════════════════════
            // ROOT PANEL  (fills form)
            // ══════════════════════════════════════════════════════════
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Padding = new System.Windows.Forms.Padding(18, 16, 18, 16);
            this.pnlRoot.Name = "pnlRoot";

            // ══════════════════════════════════════════════════════════
            // TITLE LABEL  (docked Top inside pnlRoot)
            // ══════════════════════════════════════════════════════════
            this.lblTitle.Text = "EvilHide";
            this.lblTitle.AutoSize = false;
            this.lblTitle.Height = 64;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Name = "lblTitle";

            // ══════════════════════════════════════════════════════════
            // SPLITTER  (fills pnlRoot below the title)
            // ══════════════════════════════════════════════════════════
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.splitter.SplitterWidth = 14;
            this.splitter.FixedPanel = System.Windows.Forms.FixedPanel.None;
            this.splitter.Panel1MinSize = 0;
            this.splitter.Panel2MinSize = 0;
            this.splitter.SplitterDistance = 0;
            this.splitter.Name = "splitter";

            // ══════════════════════════════════════════════════════════
            // PANEL 1  (left — HIDE panel wrapper, fills splitter.Panel1)
            // ══════════════════════════════════════════════════════════
            this.pnlHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHide.Padding = new System.Windows.Forms.Padding(16);
            this.pnlHide.Name = "pnlHide";

            // Section title (Top-docked)
            this.lblHideTitle.Text = "Encacher un secret";
            this.lblHideTitle.AutoSize = false;
            this.lblHideTitle.Height = 42;
            this.lblHideTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHideTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblHideTitle.Name = "lblHideTitle";

            // Cover file
            this.lblCoverLabel.Text = "Image Porteuse (Cover)";
            this.lblCoverLabel.AutoSize = false;
            this.lblCoverLabel.Height = 20;
            this.lblCoverLabel.Location = new System.Drawing.Point(16, 52);
            this.lblCoverLabel.Name = "lblCoverLabel";
            this.lblCoverLabel.Width = 540;

            this.btnCoverFile.Text = "Choisir l'image porteuse...";
            this.btnCoverFile.Location = new System.Drawing.Point(16, 74);
            this.btnCoverFile.Size = new System.Drawing.Size(540, 36);
            this.btnCoverFile.Name = "btnCoverFile";
            this.btnCoverFile.Click += new System.EventHandler(this.btnCoverFile_Click);

            this.lblCoverFileName.Text = "";
            this.lblCoverFileName.AutoSize = false;
            this.lblCoverFileName.Location = new System.Drawing.Point(16, 113);
            this.lblCoverFileName.Height = 18;
            this.lblCoverFileName.Width = 540;
            this.lblCoverFileName.Name = "lblCoverFileName";

            // Secret file
            this.lblSecretLabel.Text = "Image Secrète (Hidden)";
            this.lblSecretLabel.AutoSize = false;
            this.lblSecretLabel.Height = 20;
            this.lblSecretLabel.Location = new System.Drawing.Point(16, 136);
            this.lblSecretLabel.Width = 540;
            this.lblSecretLabel.Name = "lblSecretLabel";

            this.btnSecretFile.Text = "Choisir l'image secrète...";
            this.btnSecretFile.Location = new System.Drawing.Point(16, 158);
            this.btnSecretFile.Size = new System.Drawing.Size(540, 36);
            this.btnSecretFile.Name = "btnSecretFile";
            this.btnSecretFile.Click += new System.EventHandler(this.btnSecretFile_Click);

            this.lblSecretFileName.Text = "";
            this.lblSecretFileName.AutoSize = false;
            this.lblSecretFileName.Location = new System.Drawing.Point(16, 197);
            this.lblSecretFileName.Height = 18;
            this.lblSecretFileName.Width = 540;
            this.lblSecretFileName.Name = "lblSecretFileName";

            // Mask
            this.lblMaskHideLabel.Text = "Masque Binaire (Ex: 11111100 pour 2 bits)";
            this.lblMaskHideLabel.AutoSize = false;
            this.lblMaskHideLabel.Height = 20;
            this.lblMaskHideLabel.Location = new System.Drawing.Point(16, 220);
            this.lblMaskHideLabel.Width = 540;
            this.lblMaskHideLabel.Name = "lblMaskHideLabel";

            this.txtMaskHide.Text = "11111100";
            this.txtMaskHide.Location = new System.Drawing.Point(16, 242);
            this.txtMaskHide.Size = new System.Drawing.Size(540, 32);
            this.txtMaskHide.Name = "txtMaskHide";
            this.txtMaskHide.Font = new System.Drawing.Font("Cascadia Code", 12f);
            this.txtMaskHide.MaxLength = 8;

            // Fuse button
            this.btnFuse.Text = "FUSIONNER LES IMAGES";
            this.btnFuse.Location = new System.Drawing.Point(16, 286);
            this.btnFuse.Size = new System.Drawing.Size(540, 44);
            this.btnFuse.Name = "btnFuse";
            this.btnFuse.Click += new System.EventHandler(this.btnFuse_Click);

            // ── Preview area ───────────────────────────────────────────
            this.pnlHidePreview.Location = new System.Drawing.Point(16, 344);
            this.pnlHidePreview.Size = new System.Drawing.Size(540, 200);
            this.pnlHidePreview.Name = "pnlHidePreview";

            this.pnlCoverPreview.Controls.Add(this.picCover);
            this.pnlCoverPreview.Controls.Add(this.lblCoverPreviewTitle);

            // Secret Preview box
            this.pnlSecretPreview.Location = new System.Drawing.Point(180, 0);
            this.pnlSecretPreview.Size = new System.Drawing.Size(170, 200);
            this.pnlSecretPreview.Padding = new System.Windows.Forms.Padding(6);
            this.pnlSecretPreview.Name = "pnlSecretPreview";

            this.lblSecretPreviewTitle.Text = "Secret";
            this.lblSecretPreviewTitle.AutoSize = false;
            this.lblSecretPreviewTitle.Height = 20;
            this.lblSecretPreviewTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblSecretPreviewTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblSecretPreviewTitle.Name = "lblSecretPreviewTitle";

            this.picSecret.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picSecret.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picSecret.Name = "picSecret";

            this.pnlSecretPreview.Controls.Add(this.picSecret);
            this.pnlSecretPreview.Controls.Add(this.lblSecretPreviewTitle);

            // Right preview box (Composite)
            this.pnlCompositePreview.Location = new System.Drawing.Point(360, 0);
            this.pnlCompositePreview.Size = new System.Drawing.Size(180, 200);
            this.pnlCompositePreview.Padding = new System.Windows.Forms.Padding(6);
            this.pnlCompositePreview.Name = "pnlCompositePreview";

            this.lblCompositeTitle.Text = "Composite";
            this.lblCompositeTitle.AutoSize = false;
            this.lblCompositeTitle.Height = 20;
            this.lblCompositeTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCompositeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblCompositeTitle.Name = "lblCompositeTitle";

            this.picComposite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picComposite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picComposite.Name = "picComposite";

            this.btnDownload.Text = "💾  Télécharger";
            this.btnDownload.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDownload.Height = 28;
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Click += new System.EventHandler(this.btnDownload_Click);

            this.pnlCompositePreview.Controls.Add(this.picComposite);
            this.pnlCompositePreview.Controls.Add(this.btnDownload);
            this.pnlCompositePreview.Controls.Add(this.lblCompositeTitle);

            this.pnlHidePreview.Controls.Add(this.pnlCompositePreview);
            this.pnlHidePreview.Controls.Add(this.pnlSecretPreview);
            this.pnlHidePreview.Controls.Add(this.pnlCoverPreview);

            // Bit viewer
            this.rtbHideBits.Location = new System.Drawing.Point(16, 552);
            this.rtbHideBits.Size = new System.Drawing.Size(540, 120);
            this.rtbHideBits.Text = "Prêt...";
            this.rtbHideBits.ReadOnly = true;
            this.rtbHideBits.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbHideBits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbHideBits.Font = new System.Drawing.Font("Cascadia Code", 9f);
            this.rtbHideBits.Name = "rtbHideBits";

            // Add all hide controls
            this.pnlHide.Controls.Add(this.rtbHideBits);
            this.pnlHide.Controls.Add(this.pnlHidePreview);
            this.pnlHide.Controls.Add(this.btnFuse);
            this.pnlHide.Controls.Add(this.txtMaskHide);
            this.pnlHide.Controls.Add(this.lblMaskHideLabel);
            this.pnlHide.Controls.Add(this.lblSecretFileName);
            this.pnlHide.Controls.Add(this.btnSecretFile);
            this.pnlHide.Controls.Add(this.lblSecretLabel);
            this.pnlHide.Controls.Add(this.lblCoverFileName);
            this.pnlHide.Controls.Add(this.btnCoverFile);
            this.pnlHide.Controls.Add(this.lblCoverLabel);
            this.pnlHide.Controls.Add(this.lblHideTitle);

            // ══════════════════════════════════════════════════════════
            // PANEL 2  (right — EXTRACT panel wrapper, fills splitter.Panel2)
            // ══════════════════════════════════════════════════════════
            this.pnlExtract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExtract.Padding = new System.Windows.Forms.Padding(16);
            this.pnlExtract.Name = "pnlExtract";

            this.lblExtractTitle.Text = "Extraire un secret";
            this.lblExtractTitle.AutoSize = false;
            this.lblExtractTitle.Height = 42;
            this.lblExtractTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExtractTitle.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lblExtractTitle.Name = "lblExtractTitle";

            // Target file
            this.lblTargetLabel.Text = "Charger une Image Composite";
            this.lblTargetLabel.AutoSize = false;
            this.lblTargetLabel.Height = 20;
            this.lblTargetLabel.Location = new System.Drawing.Point(16, 52);
            this.lblTargetLabel.Width = 540;
            this.lblTargetLabel.Name = "lblTargetLabel";

            this.btnTargetFile.Text = "Choisir l'image composite...";
            this.btnTargetFile.Location = new System.Drawing.Point(16, 74);
            this.btnTargetFile.Size = new System.Drawing.Size(540, 36);
            this.btnTargetFile.Name = "btnTargetFile";
            this.btnTargetFile.Click += new System.EventHandler(this.btnTargetFile_Click);

            this.lblTargetFileName.Text = "";
            this.lblTargetFileName.AutoSize = false;
            this.lblTargetFileName.Location = new System.Drawing.Point(16, 113);
            this.lblTargetFileName.Height = 18;
            this.lblTargetFileName.Width = 540;
            this.lblTargetFileName.Name = "lblTargetFileName";

            // Mask
            this.lblMaskExtractLabel.Text = "Masque Binaire utilisé (Ex: 11111100)";
            this.lblMaskExtractLabel.AutoSize = false;
            this.lblMaskExtractLabel.Height = 20;
            this.lblMaskExtractLabel.Location = new System.Drawing.Point(16, 136);
            this.lblMaskExtractLabel.Width = 540;
            this.lblMaskExtractLabel.Name = "lblMaskExtractLabel";

            this.txtMaskExtract.Text = "11111100";
            this.txtMaskExtract.Location = new System.Drawing.Point(16, 158);
            this.txtMaskExtract.Size = new System.Drawing.Size(540, 32);
            this.txtMaskExtract.Name = "txtMaskExtract";
            this.txtMaskExtract.Font = new System.Drawing.Font("Cascadia Code", 12f);
            this.txtMaskExtract.MaxLength = 8;

            // Decode button
            this.btnDecode.Text = "DÉCODER LE SECRET";
            this.btnDecode.Location = new System.Drawing.Point(16, 202);
            this.btnDecode.Size = new System.Drawing.Size(540, 44);
            this.btnDecode.Name = "btnDecode";
            this.btnDecode.Click += new System.EventHandler(this.btnDecode_Click);

            // Extract preview
            this.pnlExtractPreview.Location = new System.Drawing.Point(16, 260);
            this.pnlExtractPreview.Size = new System.Drawing.Size(540, 280);
            this.pnlExtractPreview.Padding = new System.Windows.Forms.Padding(6);
            this.pnlExtractPreview.Name = "pnlExtractPreview";

            this.lblExtractedTitle.Text = "Image Extraite";
            this.lblExtractedTitle.AutoSize = false;
            this.lblExtractedTitle.Height = 24;
            this.lblExtractedTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExtractedTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblExtractedTitle.Name = "lblExtractedTitle";

            this.picExtracted.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picExtracted.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picExtracted.Name = "picExtracted";

            this.pnlExtractPreview.Controls.Add(this.picExtracted);
            this.pnlExtractPreview.Controls.Add(this.lblExtractedTitle);

            // Bit viewer
            this.rtbExtractBits.Location = new System.Drawing.Point(16, 548);
            this.rtbExtractBits.Size = new System.Drawing.Size(540, 120);
            this.rtbExtractBits.Text = "En attente de fichier...";
            this.rtbExtractBits.ReadOnly = true;
            this.rtbExtractBits.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.rtbExtractBits.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.rtbExtractBits.Font = new System.Drawing.Font("Cascadia Code", 9f);
            this.rtbExtractBits.Name = "rtbExtractBits";

            // Add all extract controls
            this.pnlExtract.Controls.Add(this.rtbExtractBits);
            this.pnlExtract.Controls.Add(this.pnlExtractPreview);
            this.pnlExtract.Controls.Add(this.btnDecode);
            this.pnlExtract.Controls.Add(this.txtMaskExtract);
            this.pnlExtract.Controls.Add(this.lblMaskExtractLabel);
            this.pnlExtract.Controls.Add(this.lblTargetFileName);
            this.pnlExtract.Controls.Add(this.btnTargetFile);
            this.pnlExtract.Controls.Add(this.lblTargetLabel);
            this.pnlExtract.Controls.Add(this.lblExtractTitle);

            // ══════════════════════════════════════════════════════════
            // WIRE INTO SPLITTER PANELS
            // ══════════════════════════════════════════════════════════
            this.splitter.Panel1.Controls.Add(this.pnlHide);
            this.splitter.Panel2.Controls.Add(this.pnlExtract);

            // ══════════════════════════════════════════════════════════
            // DIALOGS
            // ══════════════════════════════════════════════════════════
            this.dlgCover.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif|All files|*.*";
            this.dlgCover.Title = "Sélectionner l'image porteuse";
            this.dlgSecret.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif|All files|*.*";
            this.dlgSecret.Title = "Sélectionner l'image secrète";
            this.dlgTarget.Filter = "Images|*.png;*.jpg;*.jpeg;*.bmp;*.gif|All files|*.*";
            this.dlgTarget.Title = "Sélectionner l'image composite";
            this.dlgSave.Filter = "PNG Image|*.png";
            this.dlgSave.FileName = "encoded_secret.png";
            this.dlgSave.Title = "Sauvegarder le composite";

            // ══════════════════════════════════════════════════════════
            // ASSEMBLE ROOT   title (Top) + splitter (Fill)
            // Fill must be added AFTER Top-docked controls
            // ══════════════════════════════════════════════════════════
            this.pnlRoot.Controls.Add(this.splitter);  // Fill — added first so it stacks below
            this.pnlRoot.Controls.Add(this.lblTitle);  // Top  — added second = rendered on top / docked first

            this.Controls.Add(this.pnlRoot);

            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            this.splitter.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        #endregion

        // ── Control fields ────────────────────────────────────────────────────
        private System.Windows.Forms.Panel pnlRoot;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.SplitContainer splitter;

        // Hide side
        private System.Windows.Forms.Panel pnlHide;
        private System.Windows.Forms.Label lblHideTitle;
        private System.Windows.Forms.Label lblCoverLabel;
        private System.Windows.Forms.Button btnCoverFile;
        private System.Windows.Forms.Label lblCoverFileName;
        private System.Windows.Forms.Label lblSecretLabel;
        private System.Windows.Forms.Button btnSecretFile;
        private System.Windows.Forms.Label lblSecretFileName;
        private System.Windows.Forms.Label lblMaskHideLabel;
        private System.Windows.Forms.TextBox txtMaskHide;
        private System.Windows.Forms.Button btnFuse;
        private System.Windows.Forms.Panel pnlHidePreview;
        private System.Windows.Forms.Panel pnlCoverPreview;
        private System.Windows.Forms.Label lblCoverPreviewTitle;
        private EvilCorp.PixelBox picCover;
        private System.Windows.Forms.Panel pnlSecretPreview;
        private System.Windows.Forms.Label lblSecretPreviewTitle;
        private EvilCorp.PixelBox picSecret;
        private System.Windows.Forms.Panel pnlCompositePreview;
        private System.Windows.Forms.Label lblCompositeTitle;
        private EvilCorp.PixelBox picComposite;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.RichTextBox rtbHideBits;

        // Extract side
        private System.Windows.Forms.Panel pnlExtract;
        private System.Windows.Forms.Label lblExtractTitle;
        private System.Windows.Forms.Label lblTargetLabel;
        private System.Windows.Forms.Button btnTargetFile;
        private System.Windows.Forms.Label lblTargetFileName;
        private System.Windows.Forms.Label lblMaskExtractLabel;
        private System.Windows.Forms.TextBox txtMaskExtract;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Panel pnlExtractPreview;
        private System.Windows.Forms.Label lblExtractedTitle;
        private EvilCorp.PixelBox picExtracted;
        private System.Windows.Forms.RichTextBox rtbExtractBits;

        // Dialogs
        private System.Windows.Forms.OpenFileDialog dlgCover;
        private System.Windows.Forms.OpenFileDialog dlgSecret;
        private System.Windows.Forms.OpenFileDialog dlgTarget;
        private System.Windows.Forms.SaveFileDialog dlgSave;
    }
}
