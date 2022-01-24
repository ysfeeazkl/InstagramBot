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

namespace SEBusiness.Takipİşlemleri
{
    public class FWişlemleri : IFWetme
    {     
        IDBişlemleri servis = new Veritabanİşlemler();
     
        public void RakipTakipBaşlat(int KullanıcıId)
        {

            #region Hesabımıza girme
            var kullanıcıGiriş = servis.KullanıcıBilgisi(KullanıcıId);

            ChromeDriverService ChService = ChromeDriverService.CreateDefaultService(); //ChromeDriverService sınıfından ChService nesnesi üretiyoruz amacımız çıkan konsol ekranını gizlemek
            ChService.HideCommandPromptWindow = true; //konsol ekranını gizliyoruz

            IWebDriver driver = new ChromeDriver(ChService);
            driver.Navigate().GoToUrl("https://www.instagram.com/"); //başladığında instayı açma

            Thread.Sleep(2000); //programı 2.5 saniye uyutma

            IWebElement userName = driver.FindElement(By.Name("username")); //kullanıcı adı text boxının id sini çekme
            IWebElement password = driver.FindElement(By.Name("password")); //şifre text boxının id sini çekme
            IWebElement loginBtn = driver.FindElement(By.CssSelector(".sqdOP.L3NKy.y3zKF")); //giriş butonunun id si

            userName.SendKeys($"{kullanıcıGiriş[0]}"); //girilecek olan hesabın adı
            password.SendKeys($"{kullanıcıGiriş[1]}"); //girilicek olan hesabın şifresi 
            loginBtn.Click(); //giriş butonuna tıklama
            Thread.Sleep(2000); //programı 2.5 saniye uyutma
            #endregion

            var HesapÇekme = servis.HesapAdları();

            for (int i = 0; i < HesapÇekme.Count; i++)
            {

                driver.Navigate().GoToUrl($"https://www.instagram.com/{HesapÇekme[i]}");

                //burada takip olayı yok birisini takip etmesin diye koymadım
                Thread.Sleep(1000);
            }
            driver.Quit();//chrome u kapatıyo

            servis.delete("delete from HesapBilgileri");
        }
    }
}
