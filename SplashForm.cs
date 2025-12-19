using System;
using System.Drawing;
using System.Windows.Forms;

namespace SehirYonetimiVTYS // <-- BUNU Form1.cs'deki namespace ile AYNI yap
{
    public class SplashForm : Form
    {
       // private readonly Timer timer = new Timer();
       private readonly System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer();

        private readonly ProgressBar bar = new ProgressBar();
        private readonly Label status = new Label();

        public SplashForm()
        {
            // Form ayarları
            Text = "Şehir Yönetimi VTYS";
            Size = new Size(800, 450);
            StartPosition = FormStartPosition.CenterScreen;
            FormBorderStyle = FormBorderStyle.None;
            BackColor = Color.FromArgb(20, 30, 45);

            // Başlık
            var title = new Label
            {
                Text = "ŞEHİR YÖNETİMİ\nOTOPARK & İSTASYON VTYS",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 20, FontStyle.Bold),
                AutoSize = true,
                Location = new Point(180, 80)
            };

            // Alt açıklama
            var subtitle = new Label
            {
                Text = "Park Alanları • Şarj & Akaryakıt İstasyonları\nSensörler • Uyarılar • Raporlama",
                ForeColor = Color.Gainsboro,
                Font = new Font("Segoe UI", 11),
                AutoSize = true,
                Location = new Point(240, 170)
            };

            // Durum yazısı
            status.Text = "Sistem başlatılıyor...";
            status.ForeColor = Color.Gainsboro;
            status.AutoSize = true;
            status.Location = new Point(30, 380);

            // ProgressBar
            bar.Size = new Size(300, 18);
            bar.Location = new Point(450, 375);
            bar.Minimum = 0;
            bar.Maximum = 100;
            bar.Value = 0;

            // Timer
            timer.Interval = 40;
            timer.Tick += Timer_Tick;
            timer.Start();

            Controls.Add(title);
            Controls.Add(subtitle);
            Controls.Add(status);
            Controls.Add(bar);
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            // MAX'ı geçmesin diye güvenli artırma
            if (bar.Value < bar.Maximum)
                bar.Value += 1;

            if (bar.Value == 25) status.Text = "Park alanları yükleniyor...";
            else if (bar.Value == 50) status.Text = "İstasyon modülü hazırlanıyor...";
            else if (bar.Value == 75) status.Text = "Sensör ve uyarı sistemi başlatılıyor...";

            if (bar.Value >= bar.Maximum)
            {
                timer.Stop();

                var main = new Form1(); // Ana formun adı Form1 ise böyle
                main.FormClosed += (s, args) => this.Close(); // main kapanınca uygulama bitsin

                main.Show();
                this.Hide();
            }
        }
    }
}
