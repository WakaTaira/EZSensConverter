using System.Diagnostics;
using System.Reflection;

namespace EZSensConverter {
public class Base : Form {
    protected void getOnlyNums (object sender, KeyPressEventArgs e) {
        if (e.KeyChar != '\b' && (e.KeyChar < '0' || '9' < e.KeyChar) && e.KeyChar != '.') {
            e.Handled = true;
            return;
        }
    }
    protected void urlClick (object sender, EventArgs e) {
        string url = "";
        if (sender is LinkLabel link) {
            link.LinkVisited = true;
            url              = link.Text;
        } else if (sender is ToolStripMenuItem item) {
            url = item.Name;
        }
        var info = new ProcessStartInfo { UseShellExecute = true, FileName = url };
        Process.Start (info);
    }
    protected void urlClick (object sender, LinkClickedEventArgs e) {
        var info = new ProcessStartInfo { UseShellExecute = true, FileName = e.LinkText };
        Process.Start (info);
    }
    protected string myTwitter = "https://twitter.com/IAMNuN999";
    protected string myDiscord = "https://discord.com/users/496880049513955340";
    public Base() {}
}
public partial class Form1 : Base {
    private readonly Label afterLabel, beforeLabel, gamelistLabel0, gamelistLabel1, aratioLabel0, aratioLabel1,
      mdratioLabel, hipfovLabel0, hipfovLabel1, hipdistLabel0, msensUrlDisc;
    private readonly LinkLabel         msensUrl;
    private readonly ComboBox          gamelistBox0, gamelistBox1, aratioBox0, aratioBox1;
    private readonly TextBox           mdratioBox, hipfovBox0, hipfovBox1, hipdistBox0, result;
    private readonly Button            pastemdratio0, pastehipfov0, pastehipfov1, pastehipdist0, doCalc;
    private readonly MenuStrip         menuStrip;
    private readonly ToolStripMenuItem helpMenuItem, versionInfoMenuItem, linkMyTwitterInfoMenuItem,
      linkMyDiscordInfoMenuItem, exitMenuItem;
    int    gameidx0, gameidx1, aridx0, aridx1;
    bool   suutihantei;
    double aratio0, aratio1, mdratio, hipfov0, hipfov1, hipdist0, hipdist1, alpha0, alpha1;
    public Form1() {
        InitializeComponent();
        Size            = new Size (600, 520);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        MinimizeBox     = false;
        MaximizeBox     = false;

        afterLabel           = new();
        beforeLabel          = new();
        afterLabel.AutoSize  = true;
        beforeLabel.AutoSize = true;
        afterLabel.Location  = new(400, 40);
        beforeLabel.Location = new(100, 40);
        afterLabel.Text      = "After";
        beforeLabel.Text     = "Before";

        gamelistLabel0          = new();
        gamelistLabel0.AutoSize = true;
        gamelistLabel0.Location = new(60, 60);
        gamelistLabel0.Text     = "・Game title";

        gamelistLabel1          = new();
        gamelistLabel1.AutoSize = true;
        gamelistLabel1.Location = new(360, 60);
        gamelistLabel1.Text     = "・Game title";

        aratioLabel0          = new();
        aratioLabel0.AutoSize = true;
        aratioLabel0.Location = new(60, 110);
        aratioLabel0.Text     = "・Aspact ratio";

        aratioLabel1          = new();
        aratioLabel1.AutoSize = true;
        aratioLabel1.Location = new(360, 110);
        aratioLabel1.Text     = "・Aspact ratio";

        mdratioLabel          = new();
        mdratioLabel.AutoSize = true;
        mdratioLabel.Location = new(60, 160);
        mdratioLabel.Text     = "・Monitor Distance [%]";

        hipfovLabel0          = new();
        hipfovLabel0.AutoSize = true;
        hipfovLabel0.Location = new(60, 210);
        hipfovLabel0.Text     = "・In-Game Hipfire FOV";

        hipfovLabel1          = new();
        hipfovLabel1.AutoSize = true;
        hipfovLabel1.Location = new(360, 210);
        hipfovLabel1.Text     = "・In-Game Hipfire FOV";

        hipdistLabel0          = new();
        hipdistLabel0.AutoSize = true;
        hipdistLabel0.Location = new(60, 260);
        hipdistLabel0.Text     = "・Hipfire 360° Distance [cm]";

        msensUrlDisc          = new();
        msensUrlDisc.AutoSize = true;
        msensUrlDisc.Location = new(120, 450);
        msensUrlDisc.Text     = "このサイトにて腰だめ振り向きの取得、振り向きからセンシへの変換が可能です";

        msensUrl          = new();
        msensUrl.AutoSize = true;
        msensUrl.Location = new(120, 430);
        msensUrl.Click += urlClick!;
        msensUrl.Text = "https://www.mouse-sensitivity.com/";

        string[] gamelist     = new string[] { "Apex", "R6S", "Valorant", "Splitgate", "CSGO", "Overwatch" };
        gamelistBox0          = new();
        gamelistBox0.Location = new(60, 80);
        gamelistBox0.Items.AddRange (gamelist);
        gamelistBox0.DropDownStyle = ComboBoxStyle.DropDownList; // 入力不可のリストにする
        gamelistBox0.SelectedIndexChanged += gameSelected0!;
        gamelistBox1          = new();
        gamelistBox1.Location = new(360, 80);
        gamelistBox1.Items.AddRange (gamelist);
        gamelistBox1.DropDownStyle = ComboBoxStyle.DropDownList; // 入力不可のリストにする
        gamelistBox1.SelectedIndexChanged += gameSelected1!;

        string[] aratiolist = new string[] { "16:9", "5:3", "16:10", "3:2", "4:3", "5:4", "1:1" };
        aratioBox0          = new();
        aratioBox0.Location = new(60, 130);
        aratioBox0.Items.AddRange (aratiolist);
        aratioBox0.DropDownStyle = ComboBoxStyle.DropDownList;
        aratioBox1               = new();
        aratioBox1.Location      = new(360, 130);
        aratioBox1.Items.AddRange (aratiolist);
        aratioBox1.DropDownStyle = ComboBoxStyle.DropDownList;

        mdratioBox                  = new();
        mdratioBox.Location         = new(60, 180);
        mdratioBox.Size             = new(120, 25);
        mdratioBox.ImeMode          = ImeMode.Disable;
        mdratioBox.ShortcutsEnabled = false;
        mdratioBox.KeyPress += getOnlyNums!;

        hipfovBox0                  = new();
        hipfovBox0.Location         = new(60, 230);
        hipfovBox0.Size             = new(120, 25);
        hipfovBox0.ImeMode          = ImeMode.Disable;
        hipfovBox0.ShortcutsEnabled = false;
        hipfovBox0.KeyPress += getOnlyNums!;

        hipfovBox1                  = new();
        hipfovBox1.Location         = new(360, 230);
        hipfovBox1.Size             = new(120, 25);
        hipfovBox1.ImeMode          = ImeMode.Disable;
        hipfovBox1.ShortcutsEnabled = false;
        hipfovBox1.KeyPress += getOnlyNums!;

        hipdistBox0                  = new();
        hipdistBox0.Location         = new(60, 280);
        hipdistBox0.Size             = new(120, 25);
        hipdistBox0.ImeMode          = ImeMode.Disable;
        hipdistBox0.ShortcutsEnabled = false;
        hipdistBox0.KeyPress += getOnlyNums!;

        pastemdratio0          = new();
        pastemdratio0.Location = new(180, 180);
        pastemdratio0.Text     = "Paste";
        pastemdratio0.Name     = "m";
        pastemdratio0.Size     = new(50, 25);
        pastemdratio0.Click += pasteFromClipBoard!;

        pastehipfov0          = new();
        pastehipfov0.Location = new(180, 230);
        pastehipfov0.Text     = "Paste";
        pastehipfov0.Name     = "f0";
        pastehipfov0.Size     = new(50, 25);
        pastehipfov0.Click += pasteFromClipBoard!;

        pastehipfov1          = new();
        pastehipfov1.Location = new(480, 230);
        pastehipfov1.Text     = "Paste";
        pastehipfov1.Name     = "f1";
        pastehipfov1.Size     = new(50, 25);
        pastehipfov1.Click += pasteFromClipBoard!;

        pastehipdist0          = new();
        pastehipdist0.Location = new(180, 280);
        pastehipdist0.Text     = "Paste";
        pastehipdist0.Name     = "d0";
        pastehipdist0.Size     = new(50, 25);
        pastehipdist0.Click += pasteFromClipBoard!;

        doCalc          = new();
        doCalc.Location = new(360, 280);
        doCalc.Name     = "計算実行";
        doCalc.Size     = new(75, 23);
        doCalc.TabIndex = 0;
        doCalc.Text     = "計算実行";
        doCalc.Click += doCalcClick!;

        result            = new();
        result.Size       = new(540, 100);
        result.Multiline  = true;
        result.ReadOnly   = true;
        result.Location   = new(40, 320);
        result.ScrollBars = ScrollBars.Vertical;
        result.Text       = "計算結果";

        menuStrip = new MenuStrip();
        SuspendLayout();
        menuStrip.SuspendLayout();
        helpMenuItem                   = new("ヘルプ(&H)");
        versionInfoMenuItem            = new("バージョン情報(&V)", null, versionInfoClick!);
        linkMyTwitterInfoMenuItem      = new("Twitter(&T)");
        linkMyDiscordInfoMenuItem      = new("Discord(&D)");
        exitMenuItem                   = new("終了(&X)", null, exitMenuItemClick!);
        linkMyTwitterInfoMenuItem.Name = myTwitter;
        linkMyDiscordInfoMenuItem.Name = myDiscord;
        linkMyTwitterInfoMenuItem.Click += urlClick!;
        linkMyDiscordInfoMenuItem.Click += urlClick!;
        helpMenuItem.DropDownItems.Add (versionInfoMenuItem);
        helpMenuItem.DropDownItems.Add (linkMyTwitterInfoMenuItem);
        helpMenuItem.DropDownItems.Add (linkMyDiscordInfoMenuItem);
        menuStrip.Items.Add (helpMenuItem);
        menuStrip.Items.Add (exitMenuItem);


        Controls.Add (afterLabel);
        Controls.Add (beforeLabel);
        Controls.Add (gamelistBox0);
        Controls.Add (gamelistBox1);
        Controls.Add (gamelistLabel0);
        Controls.Add (gamelistLabel1);
        Controls.Add (aratioBox0);
        Controls.Add (aratioBox1);
        Controls.Add (aratioLabel0);
        Controls.Add (aratioLabel1);
        Controls.Add (mdratioBox);
        Controls.Add (mdratioLabel);
        Controls.Add (msensUrl);
        Controls.Add (msensUrlDisc);
        Controls.Add (hipfovBox0);
        Controls.Add (hipfovBox1);
        Controls.Add (hipfovLabel0);
        Controls.Add (hipfovLabel1);
        Controls.Add (hipdistBox0);
        Controls.Add (hipdistLabel0);
        Controls.Add (pastemdratio0);
        Controls.Add (pastehipfov0);
        Controls.Add (pastehipfov1);
        Controls.Add (pastehipdist0);
        Controls.Add (doCalc);
        Controls.Add (result);
        Controls.Add (menuStrip);
        MainMenuStrip = menuStrip;
        menuStrip.ResumeLayout (false);
        menuStrip.PerformLayout();
        ResumeLayout (false);
        PerformLayout();
        Text = "EZSens Converter";
    }
    private void pasteFromClipBoard (object sender, EventArgs e) {
        IDataObject clipData = Clipboard.GetDataObject();
        string      clipStr;
        if (clipData.GetDataPresent (DataFormats.Text) &&
            double.TryParse ((string)clipData.GetData (DataFormats.Text), out double _)) {
            clipStr = (string)clipData.GetData (DataFormats.Text);
            switch (((Button)sender).Name) {
            case "m": mdratioBox.Text = clipStr; break;
            case "f0": hipfovBox0.Text = clipStr; break;
            case "d0": hipdistBox0.Text = clipStr; break;
            case "f1": hipfovBox1.Text = clipStr; break;
            }
        }
    }
    private static double division (string frac) {
        string[] arr = frac.Split ('/');
        return float.Parse (arr[0]) / float.Parse (arr[1]);
    }
    private static string setPrecision (double value, int digits) {
        string ret = value.ToString();
        if (ret.Length > digits + 1)
            ret = Math.Round (value, digits + (value < 1 ? 1 : 0) - ret.IndexOf ('.')).ToString();
        return ret;
    }
    protected void versionInfoClick (object sender, EventArgs e) {
        Assembly               assembly = Assembly.GetExecutingAssembly();
        AssemblyTitleAttribute assemblyTitleAttribute =
          assembly.GetCustomAttribute<AssemblyTitleAttribute>() ?? new("hoge");
        AssemblyDescriptionAttribute assemblyDescriptionAttribute =
          assembly.GetCustomAttribute<AssemblyDescriptionAttribute>() ?? new("hoge");
        Version version        = assembly.GetName().Version ?? new();
        string  title          = assemblyTitleAttribute.Title;
        string  trimmedVersion = version.ToString (2);
        string  disc           = assemblyDescriptionAttribute.Description;

        if (title == "hoge" || disc == "hoge" || version.ToString() == "0.0") {
            MessageBox.Show ("これが出たらTwitter:@IAMNuN999まで報告して", "(´;ω;｀)", MessageBoxButtons.OK,
                             MessageBoxIcon.Warning);
            return;
        }
        VersionInfo versionInfo = new(title, version, trimmedVersion, disc);
        versionInfo.ShowDialog();
    }
    private void gameSelected0 (object sender, EventArgs e) {
        gameidx0 = gamelistBox0.SelectedIndex;
        switch (gameidx0) {
        case 2:
            aratioBox0.SelectedIndex = 0;
            aratioBox0.Enabled       = false;
            hipfovBox0.Text          = "103";
            hipfovBox0.Enabled       = false;
            break;
        case 4:
            aratioBox0.Enabled = true;
            hipfovBox0.Text    = "90";
            hipfovBox0.Enabled = false;
            break;
        case 5:
            aratioBox0.SelectedIndex = 0;
            aratioBox0.Enabled       = false;
            hipfovBox0.Enabled       = true;
            break;
        default:
            aratioBox0.Enabled = true;
            hipfovBox0.Enabled = true;
            break;
        }
    }
    private void gameSelected1 (object sender, EventArgs e) {
        gameidx1 = gamelistBox1.SelectedIndex;
        switch (gameidx1) {
        case 2:
            aratioBox1.SelectedIndex = 0;
            aratioBox1.Enabled       = false;
            hipfovBox1.Text          = "103";
            hipfovBox1.ReadOnly      = true;
            break;
        case 4:
            aratioBox1.Enabled = true;
            hipfovBox1.Text    = "90";
            hipfovBox1.Enabled = false;
            break;
        case 5:
            aratioBox1.SelectedIndex = 0;
            hipfovBox1.Text          = "";
            aratioBox1.Enabled       = false;
            hipfovBox1.ReadOnly      = false;
            break;
        default:
            aratioBox1.SelectedIndex = -1;
            hipfovBox1.Text          = "";
            aratioBox1.Enabled       = true;
            hipfovBox1.ReadOnly      = false;
            break;
        }
    }
    static double verticalFOVtoHrizontalFOV (double hipfov, double aratio) {
        hipfov = 2 * Math.Atan (Math.Tan (hipfov / 2 * Math.PI / 180) * aratio) / Math.PI * 180;
        return hipfov;
    }
    static double fix4to3Hdeg (double hipfov, double aratio) {
        hipfov = 2 * Math.Atan (Math.Tan (hipfov / 2 * Math.PI / 180) * aratio * 3 / 4) / Math.PI * 180;
        return hipfov;
    }
    void calc() {
        alpha0   = Math.Atan (mdratio * Math.Tan (hipfov0 / 2 * Math.PI / 180));
        alpha1   = Math.Atan (mdratio * Math.Tan (hipfov1 / 2 * Math.PI / 180));
        hipdist1 = hipdist0 * alpha0 / alpha1;
    }
    private void doCalcClick (object sender, EventArgs e) {
        gameidx0 = gamelistBox0.SelectedIndex;
        aridx0   = aratioBox1.SelectedIndex;
        gameidx1 = gamelistBox1.SelectedIndex;
        aridx1   = aratioBox1.SelectedIndex;
        suutihantei =
          (double.TryParse (mdratioBox.Text, out mdratio) && double.TryParse (hipfovBox0.Text, out hipfov0) &&
           double.TryParse (hipfovBox1.Text, out hipfov1) && double.TryParse (hipdistBox0.Text, out hipdist0));
        if (gameidx0 == -1 || aridx0 == -1 || gameidx1 == -1 || aridx1 == -1 || !suutihantei) {
            MessageBox.Show ("値をすべて入力してください。選択以外は数値で入力してください。", "エラー",
                             MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        aratio0 = division (aratioBox1.SelectedItem.ToString()!.Replace (":", "/"));
        aratio1 = division (aratioBox1.SelectedItem.ToString()!.Replace (":", "/"));
        mdratio /= 100;
        if (mdratio > 100 || mdratio < 0) {
            MessageBox.Show ("Monitar Distanceは0から100の割合で入力してください。", "エラー", MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
            return;
        }
        if (mdratio == 0) { mdratio = 0.00000000000000000000000000000001; }
        hipfov0  = double.Parse (hipfovBox0.Text);
        hipdist0 = double.Parse (hipdistBox0.Text);
        hipfov1  = double.Parse (hipfovBox1.Text);
        if (hipdist0 < 0) {
            MessageBox.Show ("振り向きは自然数で入力してください。", "エラー", MessageBoxButtons.OK,
                             MessageBoxIcon.Error);
            return;
        }
        switch (gameidx0) {
        case 0:
            if (hipfov0 < 1 || (hipfov0 > 2 && hipfov0 < 70) || hipfov0 > 110) {
                MessageBox.Show (
                  "ApexではIn-Game FOVは70から110のゲーム内FOVで入力してください。\r\n1から2のfovScaleでも計算できます",
                  "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (hipfov0 >= 70) {
                hipfov0 = (1 + (hipfov0 - 70) * 0.01375) * 70;
            } else {
                hipfov0 *= 70;
            }
            hipfov0 = fix4to3Hdeg (hipfov0, aratio0);
            break;
        case 1:
            if (hipfov0 < 60 || hipfov0 > 90) {
                MessageBox.Show ("R6SではIn-Game FOVは60から90で入力してください。", "エラー", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                return;
            }
            hipfov0 = verticalFOVtoHrizontalFOV (hipfov0, aratio0);
            break;
        case 2: break;
        case 3:
            if (hipfov0 < 0 || hipfov0 > 180) {
                MessageBox.Show ("SplitgateではIn-Game FOVは180未満の自然数で入力してください。", "エラー",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (aridx0 != 0) {
                hipfov0 = 2 * Math.Atan (Math.Tan (hipfov0 / 2 * Math.PI / 180) * aratio0 * 9 / 16) / Math.PI * 180;
            }
            break;
        case 4: hipfov0 = fix4to3Hdeg (hipfov0, aratio0); break;
        case 5:
            if (hipfov0 < 80 || hipfov0 > 103) {
                MessageBox.Show ("OverwatchではIn-Game FOVは80から103で入力してください。", "エラー",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            break;
        default:
            MessageBox.Show (
              "出るはずのないエラーです。出すな、ボケ\r\nできればこのエラーが起きた経緯をTwitter:@IAMNuN999まで教えてください",
              "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        switch (gameidx1) {
        case 0:
            if (hipfov1 < 1 || (hipfov1 > 2 && hipfov1 < 70) || hipfov1 > 110) {
                MessageBox.Show (
                  "ApexではIn-Game FOVは70から110のゲーム内FOVで入力してください。\r\n1から2のfovScaleでも計算できます",
                  "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            } else if (hipfov1 >= 70) {
                hipfov1 = (1 + (hipfov1 - 70) * 0.01375) * 70;
            } else {
                hipfov1 *= 70;
            }
            hipfov1 = fix4to3Hdeg (hipfov1, aratio1);
            break;
        case 1:
            if (hipfov1 < 60 || hipfov1 > 90) {
                MessageBox.Show ("R6SではIn-Game FOVは60から90で入力してください。", "エラー", MessageBoxButtons.OK,
                                 MessageBoxIcon.Error);
                return;
            }
            hipfov1 = verticalFOVtoHrizontalFOV (hipfov1, aratio1);
            break;
        case 2: break;
        case 3:
            if (hipfov1 < 1 || hipfov1 > 180) {
                MessageBox.Show ("SplitgateではIn-Game FOVは180未満の自然数で入力してください。", "エラー",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (aridx1 != 0) {
                hipfov1 = 2 * Math.Atan (Math.Tan (hipfov1 / 2 * Math.PI / 180) * aratio1 * 9 / 16) / Math.PI * 180;
            }
            break;
        case 4: hipfov1 = verticalFOVtoHrizontalFOV (hipfov1, aratio1); break;
        case 5:
            if (hipfov1 < 80 || hipfov1 > 103) {
                MessageBox.Show ("OverwatchではIn-Game FOVは80から103で入力してください。", "エラー",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            break;
        default:
            MessageBox.Show (
              "出るはずのないエラーです。出すな、ボケ\r\nできればこのエラーが起きた経緯をTwitter:@IAMNuN999まで教えてください",
              "エラー", MessageBoxButtons.OK, MessageBoxIcon.Error);
            return;
        }
        calc();
        result.Text = "計算結果\r\n";
        result.AppendText ("\r\n" + gamelistBox0.Text + " で " + setPrecision (hipdist0, 8) + "[cm/360°] を\r\n" +
                           gamelistBox1.Text + " で " + setPrecision (hipdist1, 8) + "[cm/360°] に変換");
    }
    private void exitMenuItemClick (object sender, EventArgs e) { Application.Exit(); }
}
class VersionInfo : Base {
    private readonly Label? productLabel, authorLabel, versionLabel, discLabel;
    private readonly RichTextBox? discBox;
    public VersionInfo (string title, Version version, string trimmedVersion, string disc) {
        Text            = "バージョン情報";
        MaximizeBox     = false;
        MinimizeBox     = false;
        ShowInTaskbar   = false;
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Size            = new(450, 280);

        productLabel          = new();
        productLabel.AutoSize = true;
        productLabel.Text     = "・アプリ名                              " + title + " v" + trimmedVersion;
        productLabel.Location = new(30, 20);

        authorLabel          = new();
        authorLabel.AutoSize = true;
        authorLabel.Text     = "・製作者                               WakaTaira";
        authorLabel.Location = new(30, 50);

        versionLabel          = new();
        versionLabel.AutoSize = true;
        versionLabel.Text     = "・バージョン                            " + version;
        versionLabel.Location = new(30, 80);

        discLabel          = new();
        discLabel.AutoSize = true;
        discLabel.Text     = "・説明                   ";
        discLabel.Location = new(30, 110);

        discBox            = new();
        discBox.Location   = new(120, 110);
        discBox.Size       = new(270, 120);
        discBox.Multiline  = true;
        discBox.ReadOnly   = true;
        discBox.DetectUrls = true;
        discBox.Text = disc + "\r\nバグったらTwitter\r\n" + myTwitter + "\r\nDiscord\r\n" + myDiscord + "\r\nまで";
        discBox.LinkClicked += urlClick!;

        Controls.Add (productLabel);
        Controls.Add (authorLabel);
        Controls.Add (versionLabel);
        Controls.Add (discBox);
        Controls.Add (discLabel);
    }
}
}