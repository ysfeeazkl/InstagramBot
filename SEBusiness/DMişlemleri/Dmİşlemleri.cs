using DBBusiness;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SolidİnstaDeneme2;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SEBusiness.DMişlemleri
{
    public class Dmİşlemleri : IDMatma
    {      
        IDBişlemleri servis = new Veritabanİşlemler();

        public void HashtagYorumBaşlat(string AtılcakMesaj, int KullanıcıId, string HashtagAd, int PostSayı)
        {
            var kullanıcıGiriş = servis.KullanıcıBilgisi(KullanıcıId);

            //var options = new ChromeOptions();
            //options.AddArgument("--window-position=-32000,-32000");

            //var driverService = ChromeDriverService.CreateDefaultService();
            //driverService.HideCommandPromptWindow = true;

            //var driver = new ChromeDriver(driverService, options);


            ChromeDriverService ChService = ChromeDriverService.CreateDefaultService(); //ChromeDriverService sınıfından ChService nesnesi üretiyoruz amacımız çıkan konsol ekranını gizlemek
            ChService.HideCommandPromptWindow = true; //konsol ekranını gizliyoruz

            IWebDriver driver = new ChromeDriver(ChService);

            driver.Navigate().GoToUrl("https://www.instagram.com/");

            Thread.Sleep(4000);

            IWebElement userName = driver.FindElement(By.Name("username"));
            IWebElement password = driver.FindElement(By.Name("password"));
            IWebElement loginBtn = driver.FindElement(By.CssSelector(".sqdOP.L3NKy.y3zKF"));


            userName.SendKeys($"{kullanıcıGiriş[0]}");
            password.SendKeys($"{kullanıcıGiriş[1]}");
            loginBtn.Click();

            Thread.Sleep(5000);

            IWebElement aramakutusu = driver.FindElement(By.CssSelector(".eyXLr.wUAXj")); //arama yerine tıklıyo
            aramakutusu.Click();

            Thread.Sleep(1000);

            IWebElement aramakutusuyaz = driver.FindElement(By.CssSelector(".XTCLo.x3qfX.focus-visible")); //yazı yazılacak yerin classı
            aramakutusuyaz.SendKeys($"##{HashtagAd}"); //aranacak şey 


            Thread.Sleep(2000);

            IWebElement heştek = driver.FindElement(By.CssSelector(".z556c")); //çıkan en üstteki sonuca basıyo
            heştek.Click();

            Thread.Sleep(5000);

            IWebElement rakippost = driver.FindElement(By.CssSelector(".eLAPa")); //rakibin postuna giriyo
            rakippost.Click();
            Thread.Sleep(3000);

            for (int i = 0; i < PostSayı; i++)
            {
                Thread.Sleep(3000);

                IWebElement rakipyorum = driver.FindElement(By.CssSelector(".sH9wk._JgwE")); //yorum atma yerine tıklıyo
                rakipyorum.Click();
                Thread.Sleep(2000);

                IWebElement rakipyorumatma = driver.FindElement(By.CssSelector(".Ypffh.focus-visible")); //yorum yazıyo
                rakipyorumatma.SendKeys("" + AtılcakMesaj);
                Thread.Sleep(1000);

                IWebElement ilerituşu = driver.FindElement(By.CssSelector("._65Bje.coreSpriteRightPaginationArrow"));
                ilerituşu.Click();
            }

            //IWebElement yorumgonder = driver.FindElement(By.CssSelector(".sqdOPyWX7d.y3zKF")); //gönderiyo
            //yorumgonder.Click();

        }

        public void DmOlayıBaşlat(string AtılcakMesaj,int KullanıcıId)
        {
            #region HesabaGirme
            var kullanıcıGiriş = servis.KullanıcıBilgisi(KullanıcıId);

            ChromeDriverService ChService = ChromeDriverService.CreateDefaultService(); //ChromeDriverService sınıfından ChService nesnesi üretiyoruz amacımız çıkan konsol ekranını gizlemek
            ChService.HideCommandPromptWindow = true; //konsol ekranını gizliyoruz

            IWebDriver driver = new ChromeDriver(ChService);
            driver.Navigate().GoToUrl("https://www.instagram.com/");

            Thread.Sleep(3000); 

            IWebElement userName = driver.FindElement(By.Name("username")); //kullanıcı adı text boxının id sini çekme
            IWebElement password = driver.FindElement(By.Name("password")); //şifre text boxının id sini çekme
            IWebElement loginBtn = driver.FindElement(By.CssSelector(".sqdOP.L3NKy.y3zKF")); //giriş butonunun id si

            userName.SendKeys($"{kullanıcıGiriş[0]}"); //girilecek olan hesabın adı 
            password.SendKeys($"{kullanıcıGiriş[1]}"); //girilicek olan hesabın şifresi
            loginBtn.Click(); //giriş butonuna tıklama

            Thread.Sleep(4000); //programı 2.5 saniye uyutma
            #endregion

            var DmAtılcaklar = servis.HesapAdları();
  
      
            IWebElement dm = driver.FindElement(By.CssSelector(".xWeGp")); //dm sayfasına giden veri
            dm.Click();
            Thread.Sleep(3000);
            for (int i = 0; i < DmAtılcaklar.Count; i++)
            {
                if (i == 0)
                {
                    //.aOOlW.HoLwm
                    IWebElement simdidegil = driver.FindElement(By.CssSelector(".aOOlW.HoLwm")); //bildirim uyarısını kapatıyo
                    simdidegil.Click();
                    Thread.Sleep(1000);
                }
                //.QBdPU
                IWebElement dmGrup = driver.FindElement(By.CssSelector(".QBdPU")); //grup açıyo
                dmGrup.Click();
                Thread.Sleep(2000);
                IWebElement dmisim = driver.FindElement(By.CssSelector(".j_2Hd.uMkC7.M5V28")); //dm atılacak kişinin adını yazdırıyo
                dmisim.SendKeys("" + DmAtılcaklar[i]);
                Thread.Sleep(2500);
                IWebElement dmbtn = driver.FindElement(By.CssSelector(".dCJp8")); //çıkan kişiye tıklıyo
                dmbtn.Click();
                Thread.Sleep(2000);
                IWebElement ileri = driver.FindElement(By.CssSelector(".sqdOP.yWX7d.y3zKF.cB_4K")); //bitiriyo
                ileri.Click();
                Thread.Sleep(2500);
                IWebElement msg = driver.FindElement(By.CssSelector(".focus-visible")); //mesaj yazıyo
                msg.Click();
                msg.SendKeys("" + AtılcakMesaj);
                Thread.Sleep(1000);
                //IWebElement msggonder = driver.FindElement(By.CssSelector("#react-root > section > div > div.Igw0E.IwRSH.eGOV_._4EzTm > div > div > div.DPiy6.Igw0E.IwRSH.eGOV_.vwCYk > div.uueGX > div > div.Igw0E.IwRSH.eGOV_._4EzTm > div > div > div.Igw0E.IwRSH.eGOV_._4EzTm.JI_ht")); //gönderiyo //gönder butonu yerine hesapadınıun oraya tıklıyo
                //msggonder.Click();
                Thread.Sleep(3000);
            }
            driver.Quit();
        }

        public void GönderiYorumBaşlat(string AtılcakMesaj, int KullanıcıId, string RakipAd, int PostSayı)
        {
            var kullanıcıGiriş = servis.KullanıcıBilgisi(KullanıcıId);

            ChromeDriverService ChService = ChromeDriverService.CreateDefaultService(); //ChromeDriverService sınıfından ChService nesnesi üretiyoruz amacımız çıkan konsol ekranını gizlemek
            ChService.HideCommandPromptWindow = true; //konsol ekranını gizliyoruz

            IWebDriver driver = new ChromeDriver(ChService);//oluşturduğumuz driver ı tanımlarken ChromeDriver ın içine ChromeDriverService sınıfından ürettiğimiz nesneyi yazıyoruz

            driver.Navigate().GoToUrl("https://www.instagram.com/");

            Thread.Sleep(2500);

            IWebElement userName = driver.FindElement(By.Name("username")); //kullanıcı adı text boxının id sini çekme
            IWebElement password = driver.FindElement(By.Name("password")); //şifre text boxının id sini çekme
            IWebElement loginBtn = driver.FindElement(By.CssSelector(".sqdOP.L3NKy.y3zKF")); //giriş butonunun id si

            userName.SendKeys($"{kullanıcıGiriş[0]}"); //girilecek olan hesabın adı 
            password.SendKeys($"{kullanıcıGiriş[1]}"); //girilicek olan hesabın şifresi
            loginBtn.Click(); //giriş butonuna tıklama

            Thread.Sleep(2500); //programı 2.5 saniye uyutma

            driver.Navigate().GoToUrl($"https://www.instagram.com/{RakipAd}");
            Thread.Sleep(3000);

            IWebElement rakippost = driver.FindElement(By.CssSelector(".eLAPa")); //rakibin postuna giriyo
            rakippost.Click();

            for (int i = 0; i < PostSayı; i++)
            {
                Thread.Sleep(3000);

                IWebElement rakipyorum = driver.FindElement(By.CssSelector(".sH9wk._JgwE")); //yorum atma yerine tıklıyo
                rakipyorum.Click();
                Thread.Sleep(2000);

                IWebElement rakipyorumatma = driver.FindElement(By.CssSelector(".Ypffh.focus-visible")); //yorum yazıyo
                rakipyorumatma.SendKeys("" + AtılcakMesaj);
                Thread.Sleep(1000);

                IWebElement ilerituşu = driver.FindElement(By.CssSelector("._65Bje.coreSpriteRightPaginationArrow"));
                ilerituşu.Click();
            }
            



            //IWebElement yorumgonder = driver.FindElement(By.CssSelector(".sqdOPyWX7d.y3zKF")); //gönderiyo
            //yorumgonder.Click();
        }

      

        public void LinkYorumBaşlat(string AtılcakMesaj, int KullanıcıId, string Link)
        {
            var kullanıcıGiriş = servis.KullanıcıBilgisi(KullanıcıId);

            ChromeDriverService ChService = ChromeDriverService.CreateDefaultService(); //ChromeDriverService sınıfından ChService nesnesi üretiyoruz amacımız çıkan konsol ekranını gizlemek
            ChService.HideCommandPromptWindow = true; //konsol ekranını gizliyoruz

            IWebDriver driver = new ChromeDriver(ChService);//oluşturduğumuz driver ı tanımlarken ChromeDriver ın içine ChromeDriverService sınıfından ürettiğimiz nesneyi yazıyoruz

            driver.Navigate().GoToUrl("https://www.instagram.com/");

            Thread.Sleep(2500);

            IWebElement userName = driver.FindElement(By.Name("username")); //kullanıcı adı text boxının id sini çekme
            IWebElement password = driver.FindElement(By.Name("password")); //şifre text boxının id sini çekme
            IWebElement loginBtn = driver.FindElement(By.CssSelector(".sqdOP.L3NKy.y3zKF")); //giriş butonunun id si

            userName.SendKeys($"{kullanıcıGiriş[0]}"); //girilecek olan hesabın adı 
            password.SendKeys($"{kullanıcıGiriş[1]}"); //girilicek olan hesabın şifresi
            loginBtn.Click(); //giriş butonuna tıklama

            Thread.Sleep(2500); //programı 2.5 saniye uyutma

            driver.Navigate().GoToUrl($"{Link}");

            Thread.Sleep(3000);

            IWebElement rakipyorum = driver.FindElement(By.CssSelector(".sH9wk._JgwE")); //yorum atma yerine tıklıyo
            rakipyorum.Click();

            Thread.Sleep(2000);

            IWebElement rakipyorumatma = driver.FindElement(By.CssSelector(".Ypffh.focus-visible")); //yorum yazıyo
            rakipyorumatma.SendKeys("" + AtılcakMesaj);//bunu bulamıyo buraya bak

            //IWebElement yorumgonder = driver.FindElement(By.CssSelector(".sqdOPyWX7d.y3zKF")); //gönderiyo
            //yorumgonder.Click();
        }
    }
}
