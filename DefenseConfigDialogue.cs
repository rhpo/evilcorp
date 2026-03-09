using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;
using Label = System.Windows.Forms.Label;

namespace EvilCorp
{
	public class DefenseConfigDialog : Form
	{
		public bool DefenseEnabled { get; private set; }
		public int MaxFailedAttempts { get; private set; }

		private CheckBox chkEnable;
		private NumericUpDown numAttempts;
		private Button btnSave;
		private Button btnCancel;
		private Panel pnlPreview;

		private static readonly Color Bg = Color.FromArgb(7, 10, 20);
		private static readonly Color CardBorder = Color.FromArgb(32, 48, 85);
		private static readonly Color AccentGreen = Color.FromArgb(35, 200, 100);
		private static readonly Color AccentRed = Color.FromArgb(220, 55, 55);
		private static readonly Color AccentCyan = Color.FromArgb(40, 200, 220);
		private static readonly Color TextPrimary = Color.FromArgb(220, 232, 255);
		private static readonly Color TextSecondary = Color.FromArgb(80, 105, 160);

		public DefenseConfigDialog(bool currentEnabled, int currentMaxAttempts)
		{
			DefenseEnabled = currentEnabled;
			MaxFailedAttempts = currentMaxAttempts;
			BuildUI(currentEnabled, currentMaxAttempts);
		}

		private void BuildUI(bool currentEnabled, int currentMaxAttempts)
		{
			this.Text = "Defense Configuration";
			this.ClientSize = new Size(600, 500);
			this.FormBorderStyle = FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = FormStartPosition.CenterParent;
			this.BackColor = Bg;

			// ── Header ────────────────────────────────────────────────
			var pnlHeader = new Panel { Dock = DockStyle.Top, Height = 96, BackColor = Color.FromArgb(9, 12, 25) };
			pnlHeader.Paint += (s, e) =>
			{
				var g = e.Graphics;
				g.SmoothingMode = SmoothingMode.AntiAlias;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				int w = pnlHeader.Width, h = pnlHeader.Height;

				using var grad = new LinearGradientBrush(
					new Point(0, 0), new Point(w * 2 / 3, 0),
					Color.FromArgb(60, AccentGreen), Color.FromArgb(0, AccentGreen));
				g.FillRectangle(grad, 0, 0, w, h);

				using var topPen = new Pen(Color.FromArgb(160, AccentGreen), 2);
				g.DrawLine(topPen, 0, 0, w * 2 / 3, 0);

				using var botPen = new Pen(Color.FromArgb(28, 45, 80), 1);
				g.DrawLine(botPen, 0, h - 1, w, h - 1);

				// Simple drawn circle icon — no emoji
				int cx = 52, cy = h / 2;
				g.FillEllipse(new SolidBrush(Color.FromArgb(50, AccentGreen)), cx - 30, cy - 30, 60, 60);
				g.DrawEllipse(new Pen(Color.FromArgb(140, AccentGreen), 1.5f), cx - 30, cy - 30, 60, 60);
				// Draw a simple "D" lock bar shape inside circle
				using var innerPen = new Pen(AccentGreen, 2.5f);
				g.DrawArc(innerPen, cx - 10, cy - 14, 20, 16, 180, 180); // top arch
				g.DrawRectangle(new Pen(AccentGreen, 2f), cx - 12, cy - 2, 24, 16); // body

				using var titleFont = new Font("Segoe UI", 18f, FontStyle.Bold);
				g.DrawString("Defense Configuration", titleFont,
					new SolidBrush(TextPrimary), new PointF(100, cy - 20));

				using var subFont = new Font("Segoe UI", 9.5f);
				g.DrawString("Configure account lockout protection settings", subFont,
					new SolidBrush(TextSecondary), new PointF(102, cy + 10));

				using var dotBrush = new SolidBrush(Color.FromArgb(55, AccentCyan));
				for (int i = 0; i < 5; i++)
					g.FillEllipse(dotBrush, w - 88 + i * 14, 16, 7, 7);
			};

			// ── Content ───────────────────────────────────────────────
			var pnlContent = new TableLayoutPanel
			{
				Dock = DockStyle.Fill,
				Padding = new Padding(40, 28, 40, 22),
				ColumnCount = 1,
				RowCount = 6,
				BackColor = Color.Transparent
			};
			pnlContent.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
			pnlContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));   // 0 checkbox
			pnlContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));   // 1 label
			pnlContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));   // 2 numeric
			pnlContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 18F));   // 3 spacer
			pnlContent.RowStyles.Add(new RowStyle(SizeType.Absolute, 78F));   // 4 preview
			pnlContent.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));   // 5 buttons

			// ── Checkbox ──────────────────────────────────────────────
			chkEnable = new CheckBox
			{
				Text = "   Enable Account Lockout Protection",
				Checked = currentEnabled,
				Font = new Font("Segoe UI", 11f, FontStyle.Bold),
				ForeColor = TextPrimary,
				BackColor = Color.Transparent,
				Dock = DockStyle.Fill,
				Cursor = Cursors.Hand
			};
			chkEnable.CheckedChanged += (s, e) =>
			{
				numAttempts.Enabled = chkEnable.Checked;
				pnlPreview.Invalidate();
			};

			// ── Label ─────────────────────────────────────────────────
			var lblAttempts = new Label
			{
				Text = "MAX FAILED ATTEMPTS BEFORE LOCKOUT",
				Font = new Font("Consolas", 8.5f, FontStyle.Bold),
				ForeColor = Color.FromArgb(55, 95, 158),
				BackColor = Color.Transparent,
				Dock = DockStyle.Fill,
				AutoSize = false
			};

			// ── Numeric ───────────────────────────────────────────────
			numAttempts = new NumericUpDown
			{
				Minimum = 1,
				Maximum = 20,
				Value = currentMaxAttempts,
				Enabled = currentEnabled,
				Font = new Font("Consolas", 14f, FontStyle.Bold),
				BackColor = Color.FromArgb(8, 13, 26),
				ForeColor = Color.FromArgb(70, 205, 255),
				Dock = DockStyle.Fill
			};
			numAttempts.ValueChanged += (s, e) => pnlPreview.Invalidate();

			// ── Preview ───────────────────────────────────────────────
			pnlPreview = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(8, 13, 26) };
			pnlPreview.Paint += (s, e) =>
			{
				var g = e.Graphics;
				g.SmoothingMode = SmoothingMode.AntiAlias;
				g.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
				int w = pnlPreview.Width, h = pnlPreview.Height;

				g.FillRectangle(new SolidBrush(Color.FromArgb(8, 13, 26)), 0, 0, w, h);
				g.DrawRectangle(new Pen(CardBorder, 1), 0, 0, w - 1, h - 1);

				bool enabled = chkEnable.Checked;
				int max = (int)numAttempts.Value;
				Color col = enabled ? AccentGreen : TextSecondary;

				using var lf = new Font("Segoe UI", 9f, FontStyle.Bold);
				string previewText = enabled
					? $"  Lockout triggers after {max} wrong guess(es)"
					: "  Lockout is DISABLED";
				g.DrawString(previewText, lf, new SolidBrush(col), new PointF(12, 10));

				if (!enabled) return;

				int pipW = 22, pipH = 14, pipGap = 5, startX = 14, pipY = 42;
				for (int i = 0; i < max && i < 24; i++)
				{
					bool isLast = (i == max - 1);
					Color fill = isLast
						? Color.FromArgb(180, 45, 45)
						: Color.FromArgb(20, 38, 70);
					g.FillRectangle(new SolidBrush(fill), startX + i * (pipW + pipGap), pipY, pipW, pipH);
					g.DrawRectangle(new Pen(Color.FromArgb(45, 72, 120), 1), startX + i * (pipW + pipGap), pipY, pipW, pipH);
				}

				// "LOCK" text under last pip
				if (max >= 1 && max <= 24)
				{
					int lx = startX + (max - 1) * (pipW + pipGap);
					using var lockFont = new Font("Segoe UI", 7f, FontStyle.Bold);
					g.DrawString("LOCK", lockFont, new SolidBrush(AccentRed), new PointF(lx - 1, pipY + pipH + 2));
				}
			};

			// ── Buttons ───────────────────────────────────────────────
			var pnlBtns = new TableLayoutPanel
			{
				Dock = DockStyle.Fill,
				ColumnCount = 2,
				RowCount = 1,
				BackColor = Color.Transparent,
				Margin = new Padding(0)
			};
			pnlBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 55F));
			pnlBtns.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 45F));
			pnlBtns.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

			btnSave = new Button
			{
				Text = "⚡  Save & Activate",
				Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
				ForeColor = Color.FromArgb(155, 255, 185),
				BackColor = Color.FromArgb(8, 40, 20),
				FlatStyle = FlatStyle.Flat,
				Dock = DockStyle.Fill,
				Cursor = Cursors.Hand,
				Margin = new Padding(0, 10, 8, 0)
			};
			btnSave.FlatAppearance.BorderSize = 1;
			btnSave.FlatAppearance.BorderColor = Color.FromArgb(35, 170, 95);
			btnSave.FlatAppearance.MouseOverBackColor = Color.FromArgb(12, 58, 28);
			btnSave.Click += BtnSave_Click;

			btnCancel = new Button
			{
				Text = "Cancel",
				Font = new Font("Segoe UI", 10.5f, FontStyle.Bold),
				ForeColor = TextSecondary,
				BackColor = Color.FromArgb(14, 20, 38),
				FlatStyle = FlatStyle.Flat,
				Dock = DockStyle.Fill,
				Cursor = Cursors.Hand,
				Margin = new Padding(8, 10, 0, 0)
			};
			btnCancel.FlatAppearance.BorderSize = 1;
			btnCancel.FlatAppearance.BorderColor = Color.FromArgb(38, 55, 95);
			btnCancel.FlatAppearance.MouseOverBackColor = Color.FromArgb(20, 30, 55);
			btnCancel.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; this.Close(); };

			pnlBtns.Controls.Add(btnSave, 0, 0);
			pnlBtns.Controls.Add(btnCancel, 1, 0);

			pnlContent.Controls.Add(chkEnable, 0, 0);
			pnlContent.Controls.Add(lblAttempts, 0, 1);
			pnlContent.Controls.Add(numAttempts, 0, 2);
			pnlContent.Controls.Add(new Panel { BackColor = Color.Transparent }, 0, 3);
			pnlContent.Controls.Add(pnlPreview, 0, 4);
			pnlContent.Controls.Add(pnlBtns, 0, 5);

			this.Controls.Add(pnlContent);
			this.Controls.Add(pnlHeader);
		}

		private void BtnSave_Click(object sender, EventArgs e)
		{
			DefenseEnabled = chkEnable.Checked;
			MaxFailedAttempts = (int)numAttempts.Value;
			this.DialogResult = DialogResult.OK;
			this.Close();
		}
	}
}