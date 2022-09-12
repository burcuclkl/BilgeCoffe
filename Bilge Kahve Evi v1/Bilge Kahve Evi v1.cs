using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bilge_Kahve_Evi_v1
{
    public partial class Bilge_Kahve_Evi_v1 : Form
    {
        GroupBox gpExtra;
        GroupBox gpCustomer;
        Button btnHesapla;
        ListBox lstOrders;
        ComboBox cmCoffe;
        ComboBox cmCold;
        ComboBox cmHot;
        NumericUpDown numCoffe;
        NumericUpDown numCold;
        NumericUpDown numHot;
        CheckBox checkBoxFirst;
        CheckBox checkBoxSecond;
        RadioButton rdoMilkOne;
        RadioButton rdoMilkTwo;
        RadioButton rdoSizeOne;
        RadioButton rdoSizeTwo;
        RadioButton rdoSizeThree;
        Label lblToplam;
        Button btnSiparisVer;
        TextBox txtName;
        TextBox txtNum;
        RichTextBox rchTxtAdres;
        GroupBox gpOrders;
        GroupBox gpProducts;
        decimal tutar = 0;
        PictureBox pbBox2;
        PictureBox pbBox3;
        PictureBox pbBox4;
        PictureBox pbBox5;


        decimal[] coffePrices = new decimal[7];

        

        

        public Bilge_Kahve_Evi_v1()
        {
            InitializeComponent();
            CreateTitle();
            CreateCustomer();
            GetFont();
            CreateProdutcs();
            CreateListBox();
        }

       

        private void CreateProdutcs()
        {

            gpProducts = new GroupBox();
            gpProducts.Text = "Ürünler";
            gpProducts.Size = new Size(400, 370);
            gpProducts.Location = new Point(15, 280);
            this.Controls.Add(gpProducts);



            Label lblCoffe = new Label();
            lblCoffe.Location = new Point(35, 40);
            lblCoffe.Size = new Size(85, 20);
            lblCoffe.Text = "Kahveler :";
            lblCoffe.Font = GetFont();
            gpProducts.Controls.Add(lblCoffe);


            Label lblColdDrink = new Label();
            lblColdDrink.Location = new Point(25,70);
            lblColdDrink.Size = new Size(118, 20);
            lblColdDrink.Text = "Soğuk İçecekler :";
            lblColdDrink.Font = GetFont();
            gpProducts.Controls.Add(lblColdDrink);

            Label lblHotDrink = new Label();
            lblHotDrink.Location = new Point(25,100);
            lblHotDrink.Size = new Size(120, 20);
            lblHotDrink.Text = "Sıcak İçecekler :";
            lblHotDrink.Font = GetFont();
            gpProducts.Controls.Add(lblHotDrink);

            cmCoffe = new ComboBox();
            cmCoffe.Size = new Size(170, 20);
            cmCoffe.Location = new Point(145, 40);
            cmCoffe.Items.Add("Misto");            
            cmCoffe.Items.Add("Americano");
            cmCoffe.Items.Add("Bianco");
            cmCoffe.Items.Add("Cappucino");
            cmCoffe.Items.Add("Macchiato");
            cmCoffe.Items.Add("Con Panna");
            cmCoffe.Items.Add("Mocha");
            gpProducts.Controls.Add(cmCoffe);
            cmCoffe.SelectedIndexChanged += CmCoffe_SelectedIndexChanged;


            cmCold = new ComboBox();
            cmCold.Size = new Size(170, 20);
            cmCold.Items.Add("Cola");
            cmCold.Items.Add("Ayran");
            cmCold.Items.Add("Fanta");
            cmCold.Location = new Point(145, 70);
            gpProducts.Controls.Add(cmCold);

            cmHot = new ComboBox();
            cmHot.Size = new Size(170, 20);
            cmHot.Location = new Point(145, 100);
            cmHot.Items.Add("Çay");
            cmHot.Items.Add("Hot Chocolate");
            cmHot.Items.Add("Chai Tea Latte");
            gpProducts.Controls.Add(cmHot);


            numCoffe = new NumericUpDown();
            numCoffe.Value = 1;
            numCoffe.Size = new Size(60, 20);
            numCoffe.Location = new Point(320, 40);
            gpProducts.Controls.Add(numCoffe);



            numCold = new NumericUpDown();
            numCold.Value = 1;
            numCold.Size = new Size(60, 20);
            numCold.Location = new Point(320, 70);
            gpProducts.Controls.Add(numCold);


            numHot = new NumericUpDown();
            numHot.Value = 1;
            numHot.Size = new Size(60, 20);
            numHot.Location = new Point(320, 100);
            gpProducts.Controls.Add(numHot);


            gpExtra = new GroupBox();
            gpExtra.Size = new Size(380, 170);
            gpExtra.Location = new Point(10, 150);
            gpExtra.Text = "Ekstralar";
            gpProducts.Controls.Add(gpExtra);
            gpExtra.Visible = false;

            Label lblShot = new Label();
            lblShot.Text = "Shot :";
            lblShot.Size = new Size(45, 20);
            lblShot.Font = GetFont();
            lblShot.Location = new Point(20, 25);
            gpExtra.Controls.Add(lblShot);

            checkBoxFirst = new CheckBox();
            checkBoxFirst.Location = new Point(130,25);
            checkBoxFirst.Size = new Size(40, 20);
            gpExtra.Controls.Add(checkBoxFirst);
            checkBoxFirst.Text = "1x";
           
            

            checkBoxSecond = new CheckBox();
            checkBoxSecond.Location = new Point(180, 25);
            checkBoxSecond.Size = new Size(40, 20);
            gpExtra.Controls.Add(checkBoxSecond);
            checkBoxSecond.Text = "2x";


            Label lblMilk = new Label();
            lblMilk.Size = new Size(45, 20);
            lblMilk.Location = new Point(20, 55);
            lblMilk.Text = "Süt :";
            lblMilk.Font = GetFont();
            gpExtra.Controls.Add(lblMilk);

            Label lblSize = new Label();
            lblSize.Size = new Size(105, 20);
            lblSize.Location = new Point(20, 85);
            lblSize.Text = "İçecek Boyutu :";
            lblSize.Font = GetFont();
            gpExtra.Controls.Add(lblSize);

            Panel pnlMilk = new Panel();
            pnlMilk.Size = new Size(250, 25);
            pnlMilk.Location = new Point(125, 50);
            gpExtra.Controls.Add(pnlMilk);


            Panel pnlSize = new Panel();
            pnlSize.Size = new Size(250, 25);
            pnlSize.Location = new Point(125, 85);
            gpExtra.Controls.Add(pnlSize);
          

            rdoMilkOne = new RadioButton();
            rdoMilkOne.Size = new Size(60, 20);
            rdoMilkOne.Location = new Point(10, 5);
            rdoMilkOne.Text = "Yağsız";
            pnlMilk.Controls.Add(rdoMilkOne);

            rdoMilkTwo = new RadioButton();
            rdoMilkTwo.Size = new Size(60, 20);
            rdoMilkTwo.Location = new Point(80, 5);
            rdoMilkTwo.Text = "Soya";
            pnlMilk.Controls.Add(rdoMilkTwo);

            rdoSizeOne = new RadioButton();
            rdoSizeOne.Size = new Size(60, 20);
            rdoSizeOne.Location = new Point(10, 0);
            rdoSizeOne.Text = "Venti";
            rdoSizeOne.Checked = true;
            pnlSize.Controls.Add(rdoSizeOne);

            
            rdoSizeTwo = new RadioButton();
            rdoSizeTwo.Size = new Size(60, 20);
            rdoSizeTwo.Location = new Point(80, 0);
            rdoSizeTwo.Text = "Grande";
            pnlSize.Controls.Add(rdoSizeTwo);


            rdoSizeThree = new RadioButton();
            rdoSizeThree.Size = new Size(60, 20);
            rdoSizeThree.Location = new Point(150, 0);
            rdoSizeThree.Text = "Tall";           
            pnlSize.Controls.Add(rdoSizeThree);

            btnHesapla = new Button();
            btnHesapla.Size = new Size(370, 35);
            btnHesapla.Location = new Point(10, 325);
            btnHesapla.Text = "Hesapla";            
            gpProducts.Controls.Add(btnHesapla);
            btnHesapla.Click += BtnHesapla_Click;

            gpOrders = new GroupBox();
            gpOrders.Size = new Size(370, 470);
            gpOrders.Location = new Point(425, 65);
            gpOrders.Text = "Siparişler";
            this.Controls.Add(gpOrders);

           


            lblToplam = new Label();
            lblToplam.Text = "Toplam Sipariş Tutarı :   ------   TL.";
            lblToplam.Size = new Size(265, 30);
            lblToplam.Location = new Point(420, 550);
            lblToplam.Font = new Font("Arial", 12f, FontStyle.Bold);
            this.Controls.Add(lblToplam);

            btnSiparisVer = new Button();
            btnSiparisVer.Size = new Size(370, 35);
            btnSiparisVer.Location = new Point(420, 605);
            btnSiparisVer.Text = "Sipariş Ver";
            this.Controls.Add(btnSiparisVer);
            btnSiparisVer.Click += BtnSiparisVer_Click;

            pbBox2 = new PictureBox();
            pbBox2.Location = new Point(5, 30);
            pbBox2.Size = new Size(30, 30);
            pbBox2.ImageLocation = "../../resimler/kahve.png";
            pbBox2.SizeMode = PictureBoxSizeMode.StretchImage;
            gpProducts.Controls.Add(pbBox2);

            pbBox3 = new PictureBox();
            pbBox3.Location = new Point(2, 60);
            pbBox3.Size = new Size(30, 30);
            pbBox3.ImageLocation = "../../resimler/soguk.png";
            pbBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            gpProducts.Controls.Add(pbBox3);

            pbBox4 = new PictureBox();
            pbBox4.Location = new Point(1, 90);
            pbBox4.Size = new Size(30, 30);
            pbBox4.ImageLocation = "../../resimler/sıcak.png";
            pbBox4.SizeMode = PictureBoxSizeMode.StretchImage;
            gpProducts.Controls.Add(pbBox4);


            pbBox5 = new PictureBox();
            pbBox5.Location = new Point(685,545);
            pbBox5.Size = new Size(30, 30);
            pbBox5.ImageLocation = "../../resimler/money.png";
            pbBox5.SizeMode = PictureBoxSizeMode.StretchImage;
            this.Controls.Add(pbBox5);
        }

        private void CmCoffe_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmCoffe.SelectedIndex > -1)
            {
                gpExtra.Visible = true;

            }
            else
            {
                gpExtra.Visible = false;
            }
        }
        

        private void BtnSiparisVer_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            if (txtName.Text == "" || txtNum.Text == "" || rchTxtAdres.Text == "" )
            {
                MessageBox.Show("Ad Soyad ve Adres biligileri alanı zorunludur.Lütfen doldurunuz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Sayın " + name + " " + "Toplam " + tutar + " " + "TL tutarındaki siparişiniz alınmıştır." + "\n" + "Bizi tercih ettiğiniz için teşekkürler...", "İşlem Başarılı!", MessageBoxButtons.OK, MessageBoxIcon.Information);


                Application.Restart();
            }
           
        }

        private void BtnHesapla_Click(object sender, EventArgs e)
        {

           

            if (cmCold.SelectedIndex > -1)
            {
                int coldcount = Convert.ToInt32(numCold.Value);

                string cold = cmCold.SelectedItem.ToString();
                decimal coldPrice = coldcount * 5.5M;
                lstOrders.Items.Add(cold + " " + coldPrice);
                tutar = tutar + coldPrice;

            }

            if (cmHot.SelectedIndex > -1)
            {
                int hotcount = Convert.ToInt32(numHot.Value);

                string hot = cmHot.SelectedItem.ToString();
                decimal price = 0;
                if (hot == "Çay")
                {
                    price = 3;
                }
                else if (hot == "Hot Chocolate")
                {
                    price = 4.5M;
                }
                else if (hot == "Chai Tea Latte")
                {
                    price = 6.5M;
                }
                decimal hotPrice = hotcount * price;
                lstOrders.Items.Add(hot + " " + hotPrice);
                tutar = tutar + hotPrice;
            }



            if (cmCoffe.SelectedIndex > -1)
            {
                int coffeCount = Convert.ToInt32(numCoffe.Value);
                decimal shot = 0;
                if (checkBoxFirst.Checked == true)
                {
                    shot = shot + 0.75M;

                }
                if (checkBoxSecond.Checked == true)
                {
                    shot = shot + 1.5M;

                }
                decimal milk = 0;
                if (rdoMilkOne.Checked == true || rdoMilkTwo.Checked == true)
                {
                    milk = milk + 0.5M;
                }
                decimal price = coffePrices[cmCoffe.SelectedIndex];


                if (rdoSizeOne.Checked == true)
                {
                    price = (price * 1.75M );
                }
                else if (rdoSizeTwo.Checked == true)
                {
                    price = (price * 1.25M) ;
                }
                price = price + milk + shot;
                price = price * coffeCount;
                lstOrders.Items.Add(cmCoffe.SelectedItem.ToString() + " " + price);
                tutar = tutar + price;

               

            }
            

            if (rdoMilkOne.Checked==true)
            {
             lstOrders.Items.Add("Süt :" + rdoMilkOne.Text);
               
            }
            if (rdoMilkTwo.Checked==true)
            {
                lstOrders.Items.Add("Süt :" + rdoMilkTwo.Text);
            }


            if (rdoSizeOne.Checked == true)
            {
                lstOrders.Items.Add("İçecek Boyutunuz : " + rdoSizeOne.Text);
            }
            if (rdoSizeTwo.Checked==true)
            {
                lstOrders.Items.Add("İçecek Boyutunuz : " + rdoSizeTwo.Text);
            }
            if (rdoSizeThree.Checked==true)
            {
                lstOrders.Items.Add("İçecek Boyutunuz : " + rdoSizeThree.Text);
            }

            int shotAdet = 1;           

            if ((checkBoxFirst.Checked == true) && (checkBoxSecond.Checked == true))
            {
                shotAdet = shotAdet * 3;
                lstOrders.Items.Add("Shot:" + shotAdet + "x");
            }
            else if (checkBoxFirst.Checked == true)
            {
                shotAdet = shotAdet + 0;
                lstOrders.Items.Add("Shot:" + shotAdet + "x");
            }
            else if (checkBoxSecond.Checked == true)
            {
                shotAdet++;
                lstOrders.Items.Add("Shot:" + shotAdet + "x");
            }
            
            gpExtra.Hide();
            cmCoffe.SelectedIndex = -1;
            cmCold.SelectedIndex = -1;
            cmHot.SelectedIndex = -1;
            numCoffe.Value = 1;
            numCold.Value = 1;
            numHot.Value = 1;
            

            lblToplam.Text = "Toplam Sipariş Tutarı : " + tutar + " tl";


        }

        private void CreateListBox()
        {
            lstOrders = new ListBox();
            lstOrders.Size = new Size(355, 440);
            lstOrders.Location = new Point(10, 25);
            gpOrders.Controls.Add(lstOrders);
        }

        Font GetFont()
        {
            return new Font("arial", 10f);
        }

        private void CreateCustomer()
        {
            
            gpCustomer = new GroupBox();
            gpCustomer.Text = "Müşteri Bilgileri";
            gpCustomer.Size = new Size(400, 200);
            gpCustomer.Location = new Point(15, 65);
            this.Controls.Add(gpCustomer);

            Label lblName = new Label();
            lblName.Location = new Point(10, 25);
            lblName.Size = new Size(85,20);
            lblName.Text = "Ad Soyad :";
            lblName.Font = GetFont();
            gpCustomer.Controls.Add(lblName);

            Label lblNum = new Label();
            lblNum.Location = new Point(10, 50);
            lblNum.Size = new Size(85, 20);
            lblNum.Text = "Telefon :";
            lblNum.Font = GetFont();
            gpCustomer.Controls.Add(lblNum);

            Label lblAdres = new Label();
            lblAdres.Location = new Point(10, 75);
            lblAdres.Size = new Size(85, 20);
            lblAdres.Text = "Adres :";
            lblAdres.Font = GetFont();
            gpCustomer.Controls.Add(lblAdres);

            txtName = new TextBox();
            txtName.Size = new Size(290, 20);
            txtName.Location = new Point(100,25);
            gpCustomer.Controls.Add(txtName);

            txtNum = new TextBox();
            txtNum.Size = new Size(290, 20);
            txtNum.Location = new Point(100, 50);
            gpCustomer.Controls.Add(txtNum);

            rchTxtAdres = new RichTextBox();
            rchTxtAdres.Size = new Size(290, 115);
            rchTxtAdres.Location = new Point(100, 75);
            gpCustomer.Controls.Add(rchTxtAdres);
        }

        private void CreateTitle()
        {
            Label lblTitle = new Label();
            lblTitle.Location = new Point(0, 0);
            lblTitle.Size = new Size(800, 50);
            lblTitle.Text = "Bilge Kahve Evi Sipariş Ekranı";
            lblTitle.TextAlign = ContentAlignment.MiddleCenter;
            lblTitle.Font = GetFont();
            lblTitle.BackColor = Color.DarkSlateGray;
            lblTitle.ForeColor = Color.White;
            this.Controls.Add(lblTitle);


            PictureBox pbBox1 = new PictureBox();
            pbBox1.Location = new Point(250, 2);
            pbBox1.Size = new Size(50, 50);
            pbBox1.ImageLocation = "../../resimler/coffe.png";
            pbBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            lblTitle.Controls.Add(pbBox1);
           
        }

        private void Bilge_Kahve_Evi_v1_Load(object sender, EventArgs e)
        {
            this.Location = new Point(400,100);
            this.Width = 816;
            this.Height = 700;


            decimal price = 4M;
            for (int i = 0; i < 7; i++)
            {
                coffePrices[i] = price + i; 
            }            
        }
    }
}
