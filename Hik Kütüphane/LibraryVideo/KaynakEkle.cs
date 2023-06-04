using MongoDB.Driver;
using System;
using System.Windows.Forms;

namespace LibraryVideo
{
    public partial class KaynakEkle : Form
    {


        static string connectionString = "mongodb+srv://beykent:beykent@cluster0.sicshak.mongodb.net/";
        static string databaseName = "test";
        static string collectionName = "kaynaks";

        static IMongoClient client = new MongoClient(connectionString);
        static IMongoDatabase db = client.GetDatabase(databaseName);
        IMongoCollection<Kaynak> kaynaklar = db.GetCollection<Kaynak>(collectionName);

        public string imgDondur()
        {
            string[] imgL = {
                   "http://127.0.0.1:8887/HIK/public/uploads/a.png",
                   "http://127.0.0.1:8887/HIK/public/uploads/b.png",
                   "http://127.0.0.1:8887/HIK/public/uploads/c.png",
                   "http://127.0.0.1:8887/HIK/public/uploads/d.png",
                   "http://127.0.0.1:8887/HIK/public/uploads/e.png",
                   "http://127.0.0.1:8887/HIK/public/uploads/f.png",
                   "http://127.0.0.1:8887/HIK/public/uploads/g.png",
                   "http://127.0.0.1:8887/HIK/public/uploads/h.png"
        };
            Random random = new Random();

            return imgL[random.Next(0, 8)];
        }

        public string pdfDondur()
        {
            string[] pdfL = {
                    "http://127.0.0.1:8887/HIK/public/uploads/kitaplar/kitapA.pdf",
                    "http://127.0.0.1:8887/HIK/public/uploads/kitaplar/kitapB.pdf",
                    "http://127.0.0.1:8887/HIK/public/uploads/kitaplar/kitapC.pdf",
                    "http://127.0.0.1:8887/HIK/public/uploads/kitaplar/kitapD.pdf",
                    "http://127.0.0.1:8887/HIK/public/uploads/kitaplar/kitapE.pdf",
                    "http://127.0.0.1:8887/HIK/public/uploads/kitaplar/kitapF.pdf",
                    "http://127.0.0.1:8887/HIK/public/uploads/kitaplar/kitapG.pdf",
                    "http://127.0.0.1:8887/HIK/public/uploads/kitaplar/kitapH.pdf",
                    "http://127.0.0.1:8887/HIK/public/uploads/kitaplar/kitapI.pdf",
                    "http://127.0.0.1:8887/HIK/public/uploads/kitaplar/kitapJ.pdf",
            };

            Random random = new Random();

            return pdfL[random.Next(0, 10)];
        }

        public KaynakEkle()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {

            if (txtBaslik.Text != "" && txtYazar.Text != "" && cmbTur.SelectedIndex != -1 && txtDil.Text != "" && txtBasimYili.Text != "" && txtCilt.Text != "" && txtBaski.Text != "")
            {
                string img = imgDondur();
                string pdf = pdfDondur();
                string tarih = DateTime.Now.ToString();

                

                Kaynak yeniKaynak = new Kaynak(
                    img,
                    pdf,
                    txtBaslik.Text,
                    txtYazar.Text,
                    cmbTur.Text,
                    txtDil.Text,
                    txtBasimYili.Text,
                    txtCilt.Text,
                    txtBaski.Text,  
                    0,
                    tarih
                );

                

                kaynaklar.InsertOne(yeniKaynak);

                

                MessageBox.Show("Veri Kaydedildi.", "Başarılı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtBaslik.Clear();
                txtYazar.Clear();                
                txtCilt.Clear();
                txtBasimYili.Clear();
                txtDil.Clear();
                txtBaski.Clear();
            }
            else
            {
                MessageBox.Show("Boş Alan Bırakılamaz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {

            if(MessageBox.Show("Veri Silinecek Onaylıyor Musunuz", "Emin Misiniz?",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) == DialogResult.OK)
            {
                this.Close();
            }
            
        }

        private void txtPublication_TextChanged(object sender, EventArgs e)
        {

        }

        private void AddBooks_Load(object sender, EventArgs e)
        {

        }
    }
}
