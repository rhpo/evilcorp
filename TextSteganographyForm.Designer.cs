namespace EvilCorp
{
    partial class TextSteganographyForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pnlRoot = new System.Windows.Forms.Panel();
            this.lblTitle = new System.Windows.Forms.Label();
            this.splitter = new System.Windows.Forms.SplitContainer();
            this.pnlHide = new System.Windows.Forms.Panel();
            this.lblHideTitle = new System.Windows.Forms.Label();
            this.lblCoverLabel = new System.Windows.Forms.Label();
            this.btnCoverFile = new System.Windows.Forms.Button();
            this.lblCoverFileName = new System.Windows.Forms.Label();
            this.lblTextLabel = new System.Windows.Forms.Label();
            this.txtSecretText = new System.Windows.Forms.RichTextBox();
            this.lblMaskHideLabel = new System.Windows.Forms.Label();
            this.txtMaskHide = new System.Windows.Forms.TextBox();
            this.btnFuse = new System.Windows.Forms.Button();
            this.pnlHidePreview = new System.Windows.Forms.Panel();
            this.pnlCoverPreview = new System.Windows.Forms.Panel();
            this.lblCoverPreviewTitle = new System.Windows.Forms.Label();
            this.picCover = new EvilCorp.PixelBox();
            this.pnlCompositePreview = new System.Windows.Forms.Panel();
            this.lblCompositeTitle = new System.Windows.Forms.Label();
            this.picComposite = new EvilCorp.PixelBox();
            this.btnDownload = new System.Windows.Forms.Button();
            this.pnlExtract = new System.Windows.Forms.Panel();
            this.lblExtractTitle = new System.Windows.Forms.Label();
            this.lblTargetLabel = new System.Windows.Forms.Label();
            this.btnTargetFile = new System.Windows.Forms.Button();
            this.lblTargetFileName = new System.Windows.Forms.Label();
            this.lblMaskExtractLabel = new System.Windows.Forms.Label();
            this.txtMaskExtract = new System.Windows.Forms.TextBox();
            this.btnDecode = new System.Windows.Forms.Button();
            this.lblExtractedTextLabel = new System.Windows.Forms.Label();
            this.txtExtractedText = new System.Windows.Forms.RichTextBox();
            this.dlgCover = new System.Windows.Forms.OpenFileDialog();
            this.dlgTarget = new System.Windows.Forms.OpenFileDialog();
            this.dlgSave = new System.Windows.Forms.SaveFileDialog();

            ((System.ComponentModel.ISupportInitialize)(this.splitter)).BeginInit();
            this.splitter.Panel1.SuspendLayout();
            this.splitter.Panel2.SuspendLayout();
            this.splitter.SuspendLayout();
            this.pnlRoot.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComposite)).BeginInit();
            this.SuspendLayout();

            // Form
            this.ClientSize = new System.Drawing.Size(1200, 800);
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "TextSteganographyForm";
            this.Text = "EvilHide — Text Steganography";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

            // pnlRoot
            this.pnlRoot.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRoot.Padding = new System.Windows.Forms.Padding(18, 16, 18, 16);
            this.pnlRoot.Name = "pnlRoot";

            // lblTitle
            this.lblTitle.Text = "EvilHide — Texte dans Image";
            this.lblTitle.AutoSize = false;
            this.lblTitle.Height = 64;
            this.lblTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblTitle.Name = "lblTitle";

            // splitter
            this.splitter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitter.SplitterWidth = 10;
            this.splitter.Panel1MinSize = 0;
            this.splitter.Panel2MinSize = 0;
            this.splitter.SplitterDistance = 600;

            // pnlHide
            this.pnlHide.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlHide.Padding = new System.Windows.Forms.Padding(16);
            this.pnlHide.Name = "pnlHide";

            this.lblHideTitle.Text = "Cacher du texte";
            this.lblHideTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblHideTitle.Height = 40;

            this.lblCoverLabel.Text = "Image Porteur (Cover)";
            this.lblCoverLabel.Location = new System.Drawing.Point(16, 50);
            this.lblCoverLabel.Size = new System.Drawing.Size(540, 20);

            this.btnCoverFile.Text = "Choisir l'image porteur...";
            this.btnCoverFile.Location = new System.Drawing.Point(16, 75);
            this.btnCoverFile.Size = new System.Drawing.Size(540, 36);
            this.btnCoverFile.Click += (s, e) => this.btnCoverFile_Click(s, e);

            this.lblCoverFileName.Text = "";
            this.lblCoverFileName.Location = new System.Drawing.Point(16, 115);
            this.lblCoverFileName.Size = new System.Drawing.Size(540, 20);

            this.lblTextLabel.Text = "Texte secret à cacher";
            this.lblTextLabel.Location = new System.Drawing.Point(16, 140);
            this.lblTextLabel.Size = new System.Drawing.Size(540, 20);

            this.txtSecretText.Location = new System.Drawing.Point(16, 165);
            this.txtSecretText.Size = new System.Drawing.Size(540, 100);
            this.txtSecretText.BorderStyle = System.Windows.Forms.BorderStyle.None;

            this.lblMaskHideLabel.Text = "Nombre de bits LSB (1-8)";
            this.lblMaskHideLabel.Location = new System.Drawing.Point(16, 275);
            this.lblMaskHideLabel.Size = new System.Drawing.Size(540, 20);

            this.txtMaskHide.Text = "1";
            this.txtMaskHide.Location = new System.Drawing.Point(16, 300);
            this.txtMaskHide.Size = new System.Drawing.Size(540, 30);

            this.btnFuse.Text = "FUSIONNER LE TEXTE";
            this.btnFuse.Location = new System.Drawing.Point(16, 340);
            this.btnFuse.Size = new System.Drawing.Size(540, 44);
            this.btnFuse.Click += (s, e) => this.btnFuse_Click(s, e);

            this.pnlHidePreview.Location = new System.Drawing.Point(16, 400);
            this.pnlHidePreview.Size = new System.Drawing.Size(540, 200);

            this.pnlCoverPreview.Location = new System.Drawing.Point(0, 0);
            this.pnlCoverPreview.Size = new System.Drawing.Size(260, 200);
            this.lblCoverPreviewTitle.Text = "Cover";
            this.lblCoverPreviewTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCoverPreviewTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.picCover.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picCover.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pnlCoverPreview.Controls.Add(this.picCover);
            this.pnlCoverPreview.Controls.Add(this.lblCoverPreviewTitle);

            this.pnlCompositePreview.Location = new System.Drawing.Point(270, 0);
            this.pnlCompositePreview.Size = new System.Drawing.Size(270, 200);
            this.lblCompositeTitle.Text = "Composite";
            this.lblCompositeTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblCompositeTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.picComposite.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picComposite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnDownload.Text = "💾 Télécharger";
            this.btnDownload.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.btnDownload.Click += (s, e) => this.btnDownload_Click(s, e);
            this.pnlCompositePreview.Controls.Add(this.picComposite);
            this.pnlCompositePreview.Controls.Add(this.btnDownload);
            this.pnlCompositePreview.Controls.Add(this.lblCompositeTitle);

            this.pnlHidePreview.Controls.Add(this.pnlCompositePreview);
            this.pnlHidePreview.Controls.Add(this.pnlCoverPreview);

            this.pnlHide.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.pnlHidePreview, this.btnFuse, this.txtMaskHide, this.lblMaskHideLabel,
                this.txtSecretText, this.lblTextLabel, this.lblCoverFileName, this.btnCoverFile,
                this.lblCoverLabel, this.lblHideTitle
            });

            // pnlExtract
            this.pnlExtract.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlExtract.Padding = new System.Windows.Forms.Padding(16);

            this.lblExtractTitle.Text = "Extraire du texte";
            this.lblExtractTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.lblExtractTitle.Height = 40;

            this.lblTargetLabel.Text = "Image Composite";
            this.lblTargetLabel.Location = new System.Drawing.Point(16, 50);
            this.lblTargetLabel.Size = new System.Drawing.Size(540, 20);

            this.btnTargetFile.Text = "Choisir l'image composite...";
            this.btnTargetFile.Location = new System.Drawing.Point(16, 75);
            this.btnTargetFile.Size = new System.Drawing.Size(540, 36);
            this.btnTargetFile.Click += (s, e) => this.btnTargetFile_Click(s, e);

            this.lblTargetFileName.Text = "";
            this.lblTargetFileName.Location = new System.Drawing.Point(16, 115);
            this.lblTargetFileName.Size = new System.Drawing.Size(540, 20);

            this.lblMaskExtractLabel.Text = "Nombre de bits LSB (1-8)";
            this.lblMaskExtractLabel.Location = new System.Drawing.Point(16, 140);
            this.lblMaskExtractLabel.Size = new System.Drawing.Size(540, 20);

            this.txtMaskExtract.Text = "1";
            this.txtMaskExtract.Location = new System.Drawing.Point(16, 165);
            this.txtMaskExtract.Size = new System.Drawing.Size(540, 30);

            this.btnDecode.Text = "DÉCODER LE TEXTE";
            this.btnDecode.Location = new System.Drawing.Point(16, 210);
            this.btnDecode.Size = new System.Drawing.Size(540, 44);
            this.btnDecode.Click += (s, e) => this.btnDecode_Click(s, e);

            this.lblExtractedTextLabel.Text = "Texte extrait";
            this.lblExtractedTextLabel.Location = new System.Drawing.Point(16, 270);
            this.lblExtractedTextLabel.Size = new System.Drawing.Size(540, 20);

            this.txtExtractedText.Location = new System.Drawing.Point(16, 295);
            this.txtExtractedText.Size = new System.Drawing.Size(540, 200);
            this.txtExtractedText.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtExtractedText.ReadOnly = true;

            this.pnlExtract.Controls.AddRange(new System.Windows.Forms.Control[] {
                this.txtExtractedText, this.lblExtractedTextLabel, this.btnDecode,
                this.txtMaskExtract, this.lblMaskExtractLabel, this.lblTargetFileName,
                this.btnTargetFile, this.lblTargetLabel, this.lblExtractTitle
            });

            this.splitter.Panel1.Controls.Add(this.pnlHide);
            this.splitter.Panel2.Controls.Add(this.pnlExtract);
            this.pnlRoot.Controls.Add(this.splitter);
            this.pnlRoot.Controls.Add(this.lblTitle);
            this.Controls.Add(this.pnlRoot);

            this.dlgCover.Filter = "Images (*.png;*.bmp)|*.png;*.bmp";
            this.dlgTarget.Filter = "Images (*.png;*.bmp)|*.png;*.bmp";
            this.dlgSave.Filter = "PNG Image (*.png)|*.png";

            ((System.ComponentModel.ISupportInitialize)(this.splitter)).EndInit();
            this.splitter.Panel1.ResumeLayout(false);
            this.splitter.Panel2.ResumeLayout(false);
            this.splitter.ResumeLayout(false);
            this.pnlRoot.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCover)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picComposite)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Panel pnlRoot;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.SplitContainer splitter;
        private System.Windows.Forms.Panel pnlHide;
        private System.Windows.Forms.Label lblHideTitle;
        private System.Windows.Forms.Label lblCoverLabel;
        private System.Windows.Forms.Button btnCoverFile;
        private System.Windows.Forms.Label lblCoverFileName;
        private System.Windows.Forms.Label lblTextLabel;
        private System.Windows.Forms.RichTextBox txtSecretText;
        private System.Windows.Forms.Label lblMaskHideLabel;
        private System.Windows.Forms.TextBox txtMaskHide;
        private System.Windows.Forms.Button btnFuse;
        private System.Windows.Forms.Panel pnlHidePreview;
        private System.Windows.Forms.Panel pnlCoverPreview;
        private System.Windows.Forms.Label lblCoverPreviewTitle;
        private EvilCorp.PixelBox picCover;
        private System.Windows.Forms.Panel pnlCompositePreview;
        private System.Windows.Forms.Label lblCompositeTitle;
        private EvilCorp.PixelBox picComposite;
        private System.Windows.Forms.Button btnDownload;
        private System.Windows.Forms.Panel pnlExtract;
        private System.Windows.Forms.Label lblExtractTitle;
        private System.Windows.Forms.Label lblTargetLabel;
        private System.Windows.Forms.Button btnTargetFile;
        private System.Windows.Forms.Label lblTargetFileName;
        private System.Windows.Forms.Label lblMaskExtractLabel;
        private System.Windows.Forms.TextBox txtMaskExtract;
        private System.Windows.Forms.Button btnDecode;
        private System.Windows.Forms.Label lblExtractedTextLabel;
        private System.Windows.Forms.RichTextBox txtExtractedText;
        private System.Windows.Forms.OpenFileDialog dlgCover;
        private System.Windows.Forms.OpenFileDialog dlgTarget;
        private System.Windows.Forms.SaveFileDialog dlgSave;
    }
}
