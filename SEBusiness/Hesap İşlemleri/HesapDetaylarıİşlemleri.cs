using DBBusiness;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SEBusiness.Hesap_İşlemleri
{
    public class HesapDetaylarıİşlemleri : IHesapDetayları
    {
        IDBişlemleri servis = new Veritabanİşlemler();
        List<string> kullanıcıDetayları = new List<string>();
        public List<string> RakipDetayları(string RakipAd, int KullanıcıId)
        {
            var kullanıcıGiriş = servis.KullanıcıBilgisi(KullanıcıId);

            ChromeDriverService ChService = ChromeDriverService.CreateDefaultService(); //ChromeDriverService sınıfından ChService nesnesi üretiyoruz amacımız çıkan konsol ekranını gizlemek
            ChService.HideCommandPromptWindow = true; //konsol ekranını gizliyoruz

            IWebDriver driver = new ChromeDriver(ChService);//oluşturduğumuz driver ı tanımlarken ChromeDriver ın içine ChromeDriverService sınıfından ürettiğimiz nesneyi yazıyoruz

            driver.Navigate().GoToUrl("https://www.instagram.com/");

            Thread.Sleep(3500); 

            IWebElement userName = driver.FindElement(By.Name("username")); //kullanıcı adı text boxının id sini çekme
            IWebElement password = driver.FindElement(By.Name("password")); //şifre text boxının id sini çekme
            IWebElement loginBtn = driver.FindElement(By.CssSelector(".sqdOP.L3NKy.y3zKF")); //giriş butonunun id si

            userName.SendKeys($"{kullanıcıGiriş[0]}"); //girilecek olan hesabın adı 
            password.SendKeys($"{kullanıcıGiriş[1]}"); //girilicek olan hesabın şifresi
            loginBtn.Click(); //giriş butonuna tıklama

            Thread.Sleep(2500); //programı 2.5 saniye uyutma

            driver.Navigate().GoToUrl($"https://www.instagram.com/{RakipAd}");

            Thread.Sleep(3000);

            IWebElement rakipnick = driver.FindElement(By.CssSelector("._7UhW9.fKFbl.yUEEX.KV-D4.fDxYl"));
            IWebElement rakiptakipcisayısı = driver.FindElement(By.CssSelector("#react-root > section > main > div > header > section > ul > li:nth-child(2) > a > span"));
            IWebElement rakipgönderisayısı = driver.FindElement(By.CssSelector("#react-root > section > main > div > header > section > ul > li:nth-child(1) > span > span"));                      
            IWebElement rakiptakipettiklerisayısı = driver.FindElement(By.CssSelector("#react-root > section > main > div > header > section > ul > li:nth-child(3) > a > span"));


          
         

            Thread.Sleep(1000);

            kullanıcıDetayları.Add(""+rakipnick.Text);
            kullanıcıDetayları.Add(""+rakiptakipcisayısı.Text);
            kullanıcıDetayları.Add(""+rakipgönderisayısı.Text);
            kullanıcıDetayları.Add(""+rakiptakipettiklerisayısı.Text);

            driver.Quit();
            return kullanıcıDetayları;
        }
    }
}
