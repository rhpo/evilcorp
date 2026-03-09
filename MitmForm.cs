using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Windows.Forms;

namespace EvilCorp
{
    public partial class MitmForm : Form
    {
        // --- UNIVERSAL INTERCEPTION ENGINE ---
        private const int InterceptPort = 12999;
        private TcpListener? _proxyServer;
        private Thread? _proxyThread;
        private bool _isActive = false;

        // -- New Styling Palette (Cyberpunk High-Contrast) --
        private static readonly Color BgMain = Color.FromArgb(10, 14, 28);
        private static readonly Color BgCard = Color.FromArgb(18, 22, 40);
        private static readonly Color BgHeader = Color.FromArgb(14, 18, 34);
        private static readonly Color AccentNeon = Color.FromArgb(0, 255, 180); // Cyan/Neon
        private static readonly Color AccentWarm = Color.FromArgb(255, 170, 0); // Gold/Orange
        private static readonly Color AccentAlert = Color.FromArgb(255, 60, 100); // Red/Pink
        private static readonly Color TextMain = Color.FromArgb(230, 240, 255);
        private static readonly Color TextDim = Color.FromArgb(120, 140, 180);

        public MitmForm()
        {
            InitializeComponent();
            ApplyCyberTheme();

            // Set Global Text
            lblTargetPipe.Text = "ACTIVE BROADCAST INTERCEPTION\nMode: TCP Bridge (Port 12999)\nStatus: Monitoring all local process traffic.";
            lblTargetPipe.ForeColor = TextMain;
            lblTargetPipe.Font = new Font("Segoe UI Semibold", 10f); // Larger font

            cmbTargetUser.Visible = false;
            lblListenerTitle.Text = "📡 SYSTEM PROXY";
            lblProtectionTitle.Text = "🛡 PAYLOAD PROTECTION";

            lblStatus.Text = "SYSTEM OFFLINE";
            lblStatus.ForeColor = TextDim;
        }

        private void ApplyCyberTheme()
        {
            this.BackColor = BgMain;
            this.DoubleBuffered = true;

            // Increase spacing in the left panel
            splitMain.Panel1.Padding = new Padding(20);
            splitMain.SplitterDistance = 600;

            pnlHeader.BackColor = BgHeader;
            pnlHeader.Height = 100;
            pnlHeader.Paint += (s, e) =>
            {
                var g = e.Graphics;
                g.SmoothingMode = SmoothingMode.AntiAlias;
                using var p = new Pen(Color.FromArgb(40, AccentNeon), 2);
                g.DrawLine(p, 0, pnlHeader.Height - 1, pnlHeader.Width, pnlHeader.Height - 1);

                using var fTitle = new Font("Segoe UI", 24f, FontStyle.Bold);
                using var fSub = new Font("Segoe UI", 10f);
                g.DrawString("MITM GATEWAY", fTitle, new SolidBrush(TextMain), 24, 20);
                g.DrawString("UNIFIED CROSS-PROCESS MESSAGE INTERCEPTOR v2.0", fSub, new SolidBrush(AccentNeon), 26, 62);
            };

            StyleCyberCard(pnlListenerConfig, AccentWarm);
            StyleCyberCard(pnlProtection, AccentNeon);

            StyleCyberButton(btnStartStop, AccentWarm);
            StyleCyberButton(btnToggleProtection, AccentNeon);
            StyleCyberButton(btnClearLog, AccentAlert);

            pnlLogHeader.BackColor = Color.FromArgb(12, 16, 30);
            pnlLogHeader.Height = 60; // Slightly taller
            lblLogTitle.ForeColor = AccentWarm;
            lblLogTitle.Font = new Font("Segoe UI", 14f, FontStyle.Bold); // Larger
            lblInterceptCount.ForeColor = TextMain; // Brighter

            rtbLog.BackColor = Color.FromArgb(8, 10, 20);
            rtbLog.ForeColor = TextMain;
            rtbLog.Font = new Font("Consolas", 11f); // Larger
            rtbLog.BorderStyle = BorderStyle.None;

            pnlLogHeader.Resize += (s, e) =>
            {
                btnClearLog.Location = new Point(pnlLogHeader.Width - btnClearLog.Width - 16, 10);
                lblInterceptCount.Location = new Point(btnClearLog.Location.X - lblInterceptCount.Width - 12, 18);
            };
        }

        private void StyleCyberCard(Panel pnl, Color accent)
        {
            pnl.BackColor = BgCard;
            pnl.Padding = new Padding(24);
            pnl.Margin = new Padding(0, 0, 0, 20); // Add gap between cards
            pnl.Paint += (s, e) =>
            {
                var g = e.Graphics;
                using var p = new Pen(Color.FromArgb(40, accent), 1);
                g.DrawRectangle(p, 0, 0, pnl.Width - 1, pnl.Height - 1);
                using var stripe = new SolidBrush(accent);
                g.FillRectangle(stripe, 0, 0, 4, pnl.Height);
            };

            // Recolor labels for high contrast
            foreach (Control c in pnl.Controls)
            {
                if (c is Label l)
                {
                    if (l.Name.Contains("Title")) l.ForeColor = accent;
                    else l.ForeColor = TextMain; // High contrast
                }
            }
        }

        private void StyleCyberButton(Button btn, Color color)
        {
            btn.FlatStyle = FlatStyle.Flat;
            btn.BackColor = Color.FromArgb(20, color);
            btn.ForeColor = color;
            btn.Font = new Font("Segoe UI", 11f, FontStyle.Bold); // Larger
            btn.FlatAppearance.BorderColor = Color.FromArgb(100, color);
            btn.FlatAppearance.BorderSize = 2; // Thicker border
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(40, color);
            btn.Cursor = Cursors.Hand;
            btn.Height = 54;
        }

        private void btnStartStop_Click(object? sender, EventArgs e)
        {
            if (_isActive) StopProxy(); else StartProxy();
        }

        private void StartProxy()
        {
            try
            {
                _isActive = true;
                _proxyServer = new TcpListener(IPAddress.Loopback, InterceptPort);
                _proxyServer.Start();
                _proxyThread = new Thread(ProxyLoop) { IsBackground = true };
                _proxyThread.Start();

                btnStartStop.Text = "🛑 TERMINATE PROXY";
                StyleCyberButton(btnStartStop, AccentAlert);
                lblStatus.Text = "● LISTENING: PORT 12999";
                lblStatus.ForeColor = AccentNeon;
                AppendLog("[SYSTEM] Universal Interceptor Online", AccentNeon);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Proxy Error: " + ex.Message);
                _isActive = false;
            }
        }

        private void StopProxy()
        {
            _isActive = false;
            _proxyServer?.Stop();
            btnStartStop.Text = "▶ START UNIVERSAL PROXY";
            StyleCyberButton(btnStartStop, AccentWarm);
            lblStatus.Text = "SYSTEM OFFLINE";
            lblStatus.ForeColor = TextDim;
            AppendLog("[SYSTEM] Gateway Shut Down", AccentAlert);
        }

        private void ProxyLoop()
        {
            while (_isActive)
            {
                try
                {
                    var client = _proxyServer?.AcceptTcpClient();
                    if (client == null) continue;
                    using (var s = client.GetStream())
                    using (var r = new StreamReader(s, Encoding.UTF8))
                    {
                        string? line = r.ReadLine();
                        if (!string.IsNullOrEmpty(line))
                        {
                            int sep = line.IndexOf('|');
                            if (sep > 0)
                            {
                                string pipe = line.Substring(0, sep);
                                string b64 = line.Substring(sep + 1);
                                string json = Encoding.UTF8.GetString(Convert.FromBase64String(b64));
                                this.Invoke(new Action(() => ProcessIntercept(pipe, json)));
                            }
                        }
                    }
                    client.Close();
                }
                catch { if (!_isActive) break; }
            }
        }

        private void ProcessIntercept(string pipe, string json)
        {
            string dec = "DECRYPT FAIL"; int sid = 0, rid = 0;
            try
            {
                var options = new JsonSerializerOptions { WriteIndented = true };
                var parsedDoc = JsonDocument.Parse(json);
                string formattedJson = JsonSerializer.Serialize(parsedDoc, options);

                var root = parsedDoc.RootElement;
                sid = root.GetProperty("SenderId").GetInt32();
                rid = root.GetProperty("ReceiverId").GetInt32();
                string c = root.GetProperty("Content").GetString() ?? "";
                string a = root.GetProperty("Algorithm").GetString() ?? "";
                string k = root.GetProperty("Key").GetString() ?? "";

                if (a == "Hidden")
                {
                    var (c2, a2, k2) = CryptoHelper.UnbundleMessage(c);
                    dec = TryDecrypt(c2, a2, k2);
                }
                else
                {
                    dec = TryDecrypt(c, a, k);
                }

                AppendLog($"\n[#] CAPTURED: From ID {sid} to ID {rid}", AccentWarm);
                AppendLog($"    Target Resource: {pipe}", AccentNeon);
                AppendLog($"    Message Content: \"{dec}\"", Color.White);

                using var dial = new InterceptDialog(formattedJson, dec, pipe);
                if (dial.ShowDialog(this) == DialogResult.OK)
                {
                    CommunicationChannel.SendMessage(pipe, dial.ModifiedJson, true);
                    AppendLog("    [FORWARDED] Success", AccentNeon);
                }
                else
                {
                    AppendLog("    [DROPPED] Packet Destroyed", AccentAlert);
                }
            }
            catch { }
        }

        private string TryDecrypt(string c, string a, string k)
        {
            try
            {
                if (a == "Caesar") return CryptoHelper.CaesarDecrypt(c, int.Parse(k));
                if (a == "Affine") { var p = k.Split(','); return CryptoHelper.AffineDecrypt(c, int.Parse(p[0].Trim()), int.Parse(p[1].Trim())); }
                if (a == "Hill") { var p = k.Split(','); int[,] m = { { int.Parse(p[0]), int.Parse(p[1]) }, { int.Parse(p[2]), int.Parse(p[3]) } }; return CryptoHelper.HillDecrypt(c, m); }
                return c;
            }
            catch { return "[decrypt fail]"; }
        }

        private void btnToggleProtection_Click(object? sender, EventArgs e)
        {
            MitmForm.ProtectionEnabled = !MitmForm.ProtectionEnabled; UpdateProtectionStatus();
        }

        private void UpdateProtectionStatus()
        {
            btnToggleProtection.Text = MitmForm.ProtectionEnabled ? "PROTECTION: ENABLED (Bundler Mode)" : "PROTECTION: DISABLED (Raw Mode)";
            StyleCyberButton(btnToggleProtection, MitmForm.ProtectionEnabled ? AccentNeon : AccentAlert);
        }

        private void AppendLog(string t, Color c)
        {
            int s = rtbLog.TextLength;
            rtbLog.AppendText(t + "\n");
            rtbLog.Select(s, rtbLog.TextLength - s);
            rtbLog.SelectionColor = c;
            rtbLog.ScrollToCaret();
        }

        private void btnClearLog_Click(object? sender, EventArgs e) { rtbLog.Clear(); }
        protected override void OnFormClosing(FormClosingEventArgs e) { StopProxy(); base.OnFormClosing(e); }

        // --- ROBUST PERSISTENCE ---
        private static readonly string ConfigPath = Path.Combine(Path.GetTempPath(), "evilcorp_system_config.dat");

        public static bool ProtectionEnabled
        {
            get
            {
                for (int i = 0; i < 3; i++)
                {
                    try
                    {
                        if (!File.Exists(ConfigPath)) return true;
                        using (var fs = new FileStream(ConfigPath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                        using (var sr = new StreamReader(fs)) return sr.ReadToEnd().Trim() == "1";
                    }
                    catch { Thread.Sleep(30); }
                }
                return true;
            }
            set
            {
                try
                {
                    using (var fs = new FileStream(ConfigPath, FileMode.Create, FileAccess.Write, FileShare.ReadWrite))
                    using (var sw = new StreamWriter(fs)) sw.Write(value ? "1" : "0");
                }
                catch { }
            }
        }
    }

    // ======================================================================
    //  REFINED INTERCEPT DIALOG
    // ======================================================================
    public class InterceptDialog : Form
    {
        public string ModifiedJson { get; private set; } = "";
        private readonly TextBox _txtJson;

        public InterceptDialog(string? jsonPayload, string? decryptedText, string? targetResource)
        {
            targetResource ??= "Unknown Target";
            jsonPayload ??= "{}";
            decryptedText ??= "[No Decryptable Content]";

            this.Text = "SYSTEM INTRUSION DETECTED | PACKET INSPECTION";
            this.Size = new Size(1100, 850);
            this.BackColor = Color.FromArgb(14, 18, 34);
            this.StartPosition = FormStartPosition.CenterParent;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;

            var pnlTop = new Panel { Dock = DockStyle.Top, Height = 100, BackColor = Color.FromArgb(25, 30, 50) };
            var lblH = new Label
            {
                Text = "⚡ PACKET INTERCEPTED ⚡",
                Font = new Font("Segoe UI", 26, FontStyle.Bold),
                ForeColor = Color.FromArgb(255, 170, 0),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            pnlTop.Controls.Add(lblH);
            this.Controls.Add(pnlTop);

            var pnlFooter = new Panel { Dock = DockStyle.Bottom, Height = 120, Padding = new Padding(30) };
            var btnF = CreateBtn("FORWARD MODIFIED PACKET", Color.FromArgb(0, 255, 180), DockStyle.Left);
            btnF.Click += (s, e) => { ModifiedJson = _txtJson.Text; this.DialogResult = DialogResult.OK; };
            var btnD = CreateBtn("ABORT & DESTROY", Color.FromArgb(255, 60, 100), DockStyle.Right);
            btnD.Click += (s, e) => { this.DialogResult = DialogResult.Cancel; };
            pnlFooter.Controls.Add(btnF);
            pnlFooter.Controls.Add(btnD);
            this.Controls.Add(pnlFooter);

            var pnlMainBody = new Panel { Dock = DockStyle.Fill, Padding = new Padding(40) };
            var lblPrompt = new Label { Text = "RAW DATAGRAM (EDITABLE):", Font = new Font("Segoe UI", 12, FontStyle.Bold), ForeColor = Color.White, Dock = DockStyle.Top, Height = 40 };
            var lblInfo = new Label { Text = $"TARGET: {targetResource}\nDECRYPTED CONTENT: \"{decryptedText}\"", Font = new Font("Consolas", 14f, FontStyle.Bold), ForeColor = Color.FromArgb(0, 255, 180), Dock = DockStyle.Top, Height = 100 };

            _txtJson = new TextBox
            {
                Text = jsonPayload,
                Multiline = true,
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(8, 11, 22),
                ForeColor = Color.FromArgb(0, 255, 150),
                Font = new Font("Consolas", 14f),
                BorderStyle = BorderStyle.FixedSingle,
                ScrollBars = ScrollBars.Both,
                ReadOnly = false
            };

            pnlMainBody.Controls.Add(_txtJson);
            pnlMainBody.Controls.Add(lblPrompt);
            pnlMainBody.Controls.Add(lblInfo);
            this.Controls.Add(pnlMainBody);

            ModifiedJson = jsonPayload;
            this.Load += (s, e) => { _txtJson.Focus(); };
        }

        private Button CreateBtn(string t, Color c, DockStyle d)
        {
            return new Button { Text = t, Dock = d, Width = 450, FlatStyle = FlatStyle.Flat, BackColor = Color.FromArgb(30, c), ForeColor = c, Font = new Font("Segoe UI", 14, FontStyle.Bold), Cursor = Cursors.Hand, FlatAppearance = { BorderColor = c, BorderSize = 2 } };
        }
    }
}
