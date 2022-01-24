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

namespace SEBusiness
{
    public class TakipciCekmeİşlemi : ITakipciCekme
    {
        IDBKaraListe karalisteServisi = new KaraListeİşlemleri();
        IDBişlemleri servis = new Veritabanİşlemler();
       
      

        public List<String> HashtagDenTakipçiÇekme(string Hashtag, int KullanıcıId,bool KaralisteFiltre, int ÇekilecekSayı)
        {
            var kullanıcıGiriş = servis.KullanıcıBilgisi(KullanıcıId);

            var options = new ChromeOptions();
            options.AddArgument("--window-position=-32000,-32000");

            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            var driver = new ChromeDriver(driverService, options);

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
            aramakutusuyaz.SendKeys($"##{Hashtag}"); //aranacak şey 


            Thread.Sleep(2000);

            IWebElement heştek = driver.FindElement(By.CssSelector(".z556c")); //çıkan en üstteki sonuca basıyo
            heştek.Click();

            Thread.Sleep(5000);
 
            IWebElement rakippost = driver.FindElement(By.CssSelector(".eLAPa")); //rakibin postuna giriyo
            rakippost.Click();
            Thread.Sleep(3000);


            int girilensayi = ÇekilecekSayı;

            int sayac = 1;
            int postsayaç = 0;
            int adsayaç = 0;


            IWebElement rakipyorum;
            bool a = false;

            List<string> yorumatanlar = new List<string>();
            List<string> yorumlar = new List<string>();


            for (int j = 0; j < 100; j++)
            {
                Thread.Sleep(3000);
                //isgrP
                string jskomudu = "" +                                                            //|
                        "sayfa = document.querySelector('.XQXOT.pXf-y');" +                       //|
                        "sayfa.scrollTo(0,sayfa.scrollHeight);" +                                 //|
                        "var sayfasonu=sayfa.scrollHeight;" +                                     //| yorumları aşağı indiriyo  
                        "return sayfasonu;";                                                      //|
                                                                                                  //|
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;                             //|

                try
                {
                    for (int k = 0; k < 99999; k++)
                    {
                        if (a == true)
                        {
                            break;
                        }

                        try
                        {
                            var sayfasonu = Convert.ToInt32(js.ExecuteScript(jskomudu));
                            Thread.Sleep(2000);
                            IWebElement yyükle = driver.FindElement(By.CssSelector(".dCJp8.afkep"));
                            yyükle.Click();
                        }
                        catch
                        {


                        }

                        try
                        {
                            for (int i = 0; i < 99999; i++)
                            {
                                if (yorumlar.Count >= girilensayi + postsayaç)
                                {
                                    a = true;
                                    k = 99999;
                                    break;
                                }
                                if (sayac == 1)
                                {
                                    rakipyorum = driver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div.eo2As > div.EtaWk > ul > div > li > div > div > div.C4VMK > span"));
                                    yorumlar.Add(rakipyorum.Text);

                                    //IWebElement ilkad = driver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div.eo2As > div.EtaWk > ul > div > li > div > div > div.C4VMK > h2 > div:nth-child(1) > span > a"));
                                    //if (ilkad.Text == RakipAd)
                                    //{
                                    //    adsayaç = 1;
                                    //}

                                }
                                else
                                {
                                    rakipyorum = driver.FindElement(By.CssSelector($"body > div._2dDPU.CkGkG > div.zZYga > div > article > div.eo2As > div.EtaWk > ul > ul:nth-child({sayac}) > div > li > div > div.C7I1f > div.C4VMK > span"));
                                    yorumlar.Add(rakipyorum.Text);

                                }
                                sayac++;
                                if (yorumlar.Count >= girilensayi)
                                {
                                    a = true;
                                    k = 99999;
                                    break;

                                }
                            }


                        }
                        catch
                        {
                        }



                        try
                        {
                            IWebElement yyükle = driver.FindElement(By.CssSelector(".dCJp8.afkep"));
                            yyükle.Click();
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
                catch
                {
                }

                IReadOnlyCollection<IWebElement> yorumcular = driver.FindElements(By.CssSelector(".sqdOP.yWX7d._8A5w5.ZIAjV")); //zaten şimdi senin hesapta denicem oluyosa oldu

                foreach (IWebElement yorumatan in yorumcular) //yorum atanarı listeye atıyo 
                {
                    if (yorumatanlar.Count >= girilensayi + postsayaç)//burada da sınır var girilen kadar çekmesi için
                    {
                        a = true;
                        break; //               
                    }

                    //if (adsayaç == 1)
                    //{
                    //    adsayaç = 0;
                    //}
                    //else
                    //{
                        yorumatanlar.Add("" + yorumatan.Text);
                    //}

                }

                Thread.Sleep(3000);

                try
                {
                    if (a == true)
                    {
                        break;
                    }
                    else
                    {
                        IWebElement ilerituşu = driver.FindElement(By.CssSelector("._65Bje.coreSpriteRightPaginationArrow"));
                        ilerituşu.Click();
                        sayac = 1;

                    }

                }
                catch
                {


                }


            }
            driver.Quit();

            karalisteServisi.HesapYorumAyrıştırma(yorumatanlar, yorumlar);

            int sayaç = 0;
            for (int i = 0; i < yorumatanlar.Count; i++)
            {

                for (int j = 0; j < i; j++)
                {
                    if (yorumatanlar[i] == yorumatanlar[j])
                    {
                        sayaç++;
                    }
                }
                if (sayaç == 0)
                {
                    servis.insert($"insert HesapBilgileri (HesapAd) values ('{yorumatanlar[i]}')");
                }
                sayaç = 0;
            }

            if (KaralisteFiltre == true)
            {
                karalisteServisi.HashtagKaralisteAyırma();
            }

            var filtrelenmişTakipçi = servis.HesapAdları();

            return filtrelenmişTakipçi;
        }

        public List<string> GönderidenTakipçiÇekme(string RakipAd, int KullanıcıId,bool KaralisteFiltre, int ÇekilecekSayı)
        {        
            var kullanıcıGiriş = servis.KullanıcıBilgisi(KullanıcıId);

            var options = new ChromeOptions();
            options.AddArgument("--window-position=-32000,-32000");

            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            var driver = new ChromeDriver(driverService, options);
            driver.Navigate().GoToUrl("https://www.instagram.com/");

            Thread.Sleep(4000);

            IWebElement userName = driver.FindElement(By.Name("username"));
            IWebElement password = driver.FindElement(By.Name("password"));
            IWebElement loginBtn = driver.FindElement(By.CssSelector(".sqdOP.L3NKy.y3zKF"));


            userName.SendKeys(""+ kullanıcıGiriş[0]);
            password.SendKeys(""+ kullanıcıGiriş[1]);
            loginBtn.Click();

            Thread.Sleep(5000);

            driver.Navigate().GoToUrl("https://www.instagram.com/" + RakipAd);//esadyslyrt velettofficial

            Thread.Sleep(3000);



            IWebElement rakippost = driver.FindElement(By.CssSelector(".eLAPa")); //rakibin postuna giriyo
            rakippost.Click();
            Thread.Sleep(3000);


            int girilensayi = ÇekilecekSayı;

            int sayac = 1;
            int postsayaç = 0;
            int adsayaç = 0;


            IWebElement rakipyorum;
            bool a = false;

            List<string> yorumatanlar = new List<string>();
            List<string> yorumlar = new List<string>();


            for (int j = 0; j < 100; j++)
            {
                Thread.Sleep(3000);
                //isgrP
                string jskomudu = "" +                                                            //|
                        "sayfa = document.querySelector('.XQXOT.pXf-y');" +                       //|
                        "sayfa.scrollTo(0,sayfa.scrollHeight);" +                                 //|
                        "var sayfasonu=sayfa.scrollHeight;" +                                     //| yorumları aşağı indiriyo  
                        "return sayfasonu;";                                                      //|
                                                                                                  //|
                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;                             //|

                try
                {
                    for (int k = 0; k < 99999; k++)
                    {
                        if (a == true)
                        {
                            break;
                        }

                        try
                        {
                            var sayfasonu = Convert.ToInt32(js.ExecuteScript(jskomudu));
                            Thread.Sleep(2000);
                            IWebElement yyükle = driver.FindElement(By.CssSelector(".dCJp8.afkep"));
                            yyükle.Click();
                        }
                        catch
                        {


                        }

                        try
                        {
                            for (int i = 0; i < 99999; i++)
                            {
                                if (yorumlar.Count >= girilensayi + postsayaç)
                                {
                                    a = true;
                                    k = 99999;
                                    break;
                                }
                                if (sayac == 1)
                                {
                                    rakipyorum = driver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div.eo2As > div.EtaWk > ul > div > li > div > div > div.C4VMK > span"));
                                    IWebElement ilkad = driver.FindElement(By.CssSelector("body > div._2dDPU.CkGkG > div.zZYga > div > article > div.eo2As > div.EtaWk > ul > div > li > div > div > div.C4VMK > h2 > div:nth-child(1) > span > a"));
                                    yorumlar.Add(rakipyorum.Text);
                                    if (ilkad.Text == RakipAd)
                                    {
                                        adsayaç = 1;
                                    }

                                }
                                else
                                {
                                    rakipyorum = driver.FindElement(By.CssSelector($"body > div._2dDPU.CkGkG > div.zZYga > div > article > div.eo2As > div.EtaWk > ul > ul:nth-child({sayac}) > div > li > div > div.C7I1f > div.C4VMK > span"));
                                    yorumlar.Add(rakipyorum.Text);

                                }
                                sayac++;
                                if (yorumlar.Count >= girilensayi)
                                {
                                    a = true;
                                    k = 99999;
                                    break;

                                }
                            }


                        }
                        catch
                        {
                        }



                        try
                        {
                            IWebElement yyükle = driver.FindElement(By.CssSelector(".dCJp8.afkep"));
                            yyükle.Click();
                        }
                        catch
                        {
                            break;
                        }
                    }
                }
                catch
                {
                }

                IReadOnlyCollection<IWebElement> yorumcular = driver.FindElements(By.CssSelector(".sqdOP.yWX7d._8A5w5.ZIAjV")); //zaten şimdi senin hesapta denicem oluyosa oldu

                foreach (IWebElement yorumatan in yorumcular) //yorum atanarı listeye atıyo 
                {
                    if (yorumatanlar.Count >= girilensayi + postsayaç)//burada da sınır var girilen kadar çekmesi için
                    {
                        a = true;
                        break; //               
                    }

                    if (adsayaç == 1)
                    {
                        adsayaç = 0;
                    }
                    else
                    {
                        yorumatanlar.Add("" + yorumatan.Text);
                    }

                }

                Thread.Sleep(3000);

                try
                {
                    if (a == true)
                    {
                        break;
                    }
                    else
                    {
                        IWebElement ilerituşu = driver.FindElement(By.CssSelector("._65Bje.coreSpriteRightPaginationArrow"));
                        ilerituşu.Click();
                        sayac = 1;

                    }

                }
                catch
                {


                }


            }
            driver.Quit();

            karalisteServisi.HesapYorumAyrıştırma(yorumatanlar, yorumlar);

            int sayaç = 0;
            for (int i = 0; i < yorumatanlar.Count; i++)
            {

                for (int j = 0; j < i; j++)
                {
                    if (yorumatanlar[i] == yorumatanlar[j])
                    {
                        sayaç++;
                    }
                }
                if (sayaç == 0)
                {
                    servis.insert($"insert HesapBilgileri (HesapAd) values ('{yorumatanlar[i]}')");
                }
                sayaç = 0;
            }

            if (KaralisteFiltre == true)
            {
                karalisteServisi.KaralisteAyırma(RakipAd);
            }

            var filtrelenmişTakipçi = servis.HesapAdları();          

            return filtrelenmişTakipçi;
        }

     

        public List<string> TakipciCekmeOlayı(string RakipAd, int ÇekilecekSayı, int KullanıcıId,bool KaralisteFiltre)
        {
            List<string> adamlar = new List<string>();
            List<string> adamlarınTakibi = new List<string>();


            var kullanıcıGiriş = servis.KullanıcıBilgisi(KullanıcıId);          

            var options = new ChromeOptions();
            options.AddArgument("--window-position=-32000,-32000");

            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true;

            var driver = new ChromeDriver(driverService, options);

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

            IWebElement takipçiLink = driver.FindElement(By.CssSelector("#react-root > section > main > div > header > section > ul > li:nth-child(2) > a"));
            takipçiLink.Click();

            Thread.Sleep(2000);

            //isgrP
            string jskomudu = "" +
                "sayfa = document.querySelector('.isgrP');" +
                "sayfa.scrollTo(0,sayfa.scrollHeight);" +
                "var sayfasonu=sayfa.scrollHeight;" +
                "return sayfasonu;";

            IJavaScriptExecutor js = (IJavaScriptExecutor)driver;
            var sayfasonu = Convert.ToInt32(js.ExecuteScript(jskomudu));

            int sayac, sayacson = 0;
            for (sayac = 0; sayac < 99999; sayac = sayac + 12)
            {
                if (sayac >= ÇekilecekSayı)
                {
                    sayacson = sayac / 12;
                    break;
                }
            }
            for (int i = 0; i < sayacson; i++)
            {
                Thread.Sleep(1000);
                sayfasonu = Convert.ToInt32(js.ExecuteScript(jskomudu));
            }
            Thread.Sleep(2000);


            IReadOnlyCollection<IWebElement> takipçiler = driver.FindElements(By.CssSelector(".FPmhX.notranslate._0imsa"));
            foreach (IWebElement takipçi in takipçiler)
            {
                adamlar.Add("" + takipçi.Text);
            }
            IReadOnlyCollection<IWebElement> TakipEtButon = driver.FindElements(By.CssSelector(".Pkbci"));
            foreach (IWebElement butonDurum in TakipEtButon)
            {
                adamlarınTakibi.Add("" + butonDurum.Text);
            }

            for (int i = 0; i < ÇekilecekSayı; i++)
            {
                if (adamlarınTakibi[i] == "Follow" || adamlarınTakibi[i] == "Takip et")
                {
                    servis.insert($"insert HesapBilgileri (HesapAd,TakipDurum) values('{adamlar[i]}',1)");
                                   
                }
                else if (adamlarınTakibi[i] == "Following" || adamlarınTakibi[i] == "Takip etme")
                {
                    servis.insert($"insert HesapBilgileri (HesapAd,TakipDurum) values('{adamlar[i]}',0)");
                }
               
            }
            driver.Quit();//chrome u kapatıyo


            if (KaralisteFiltre == true)
            {
                karalisteServisi.KaralisteAyırma(RakipAd);
            }


            var FiltrelenmişTakipçi = servis.HesapAdları();

            return FiltrelenmişTakipçi;
        }
    }
}