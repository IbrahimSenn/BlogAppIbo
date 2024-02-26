using BlogApp.Entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public static class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();

            if(context != null)
            {
                if(context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }

                if(!context.Categories.Any())
                {
                    context.Categories.AddRange(
                        new Category { Text = "Yaşam", Url = "web-programlama", Color = TagColors.warning },
                        new Category { Text = "Bilim", Url="backend", Color = TagColors.info },
                        new Category { Text = "Sağlık", Url="frontend" , Color = TagColors.success },
                        new Category { Text = "Teknoloji", Url="fullstack", Color = TagColors.secondary  },
                        new Category { Text = "Twitch", Url="twitch-kapandi", Color = TagColors.primary  }
                    );
                    context.SaveChanges();
                }

                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new User { UserName = "ibrahimsen", Name = "İbrahim Şen", Email = "info@sen.com", Password="123456", Image = "11.jpg"},
                        new User { UserName = "umutönal", Name = "Umut Önal", Email = "info@umut.com", Password="123456", Image = "11.jpg"}
                    );
                    context.SaveChanges();
                }

                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new Post {
                            Title = "Twitch kapandı mı, ne zaman açılacak?",
                            Description = "Gündem",
                            Content = "Twitch’e, Bilgi Teknolojileri ve İletişim Kurumu (BTK) tarafından erişim engeli kararı alındı. Alınan kararın ardından birçok oyunsever, yayıncı ve izleyici Twitch'in açılıp açılmayacağını merak ediyor.",
                            Url = "twitch-kapandi",//Buraya bakılacak*******************
                            IsActive = true,
                            PublishedOn = DateTime.Now.AddDays(-10),
                            Categories = context.Categories.Take(3).ToList(),
                            Image = "Twitter(Gündem).png",
                            UserId = 1,
                            Comments = new List<Comment> { 
                                new Comment { Text = "çalıştık kazandık", PublishedOn = DateTime.Now.AddDays(-20), UserId = 1},
                                new Comment { Text = "kpss yerine yazılım çalışın", PublishedOn = DateTime.Now.AddDays(-10), UserId = 2},
                            }
                        },
                        new Post {
                            Title = "Araştırma: Evden çalışmanın sağlık açısından birçok faydası var",
                            Description = "Sağlık",
                            Content = "İngiltere Sağlık Güvenliği Kurumu (UKHSA) ve King’s College’da çalışan araştırmacılar, evden çalışan insanların daha az streslendiği, daha sağlıklı beslendiği ve daha düşük tansiyona sahip olduğunu söyledi.",
                            Url = "saglik",
                            IsActive = true,
                            Image = "saglik.png",
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Categories = context.Categories.Take(2).ToList(),
                            UserId = 1
                        },
                        new Post {
                            Title = "ChatGPT’nin alakasız cevaplarına şikayet arttı",
                            Description = "Bilim",
                            Content = "Gensler adlı mimarlık firmasının ortaklarından Sean McGuire, ChatGPT'nin kendisine saçma İngilizce ve İspanyolca kelimelerin karışımı olan Spanglish adı verilen bir argo dille yanıtlar verdiği ekran görüntülerini paylaştı.",
                            Url = "Chat",
                            IsActive = true,
                            Image = "Chat.png",
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Categories = context.Categories.Take(2).ToList(),
                            UserId = 1
                        },
                        new Post {
                            Title = "Teknoloji şirketleri için en büyük 10 fırsat",
                            Description = "Bilim",
                            Content = "GGelişmekte olan pazarlarda ek tedarik zinciri hatları oluşturmanın önemli olduğu vurgulanan araştırmada jeopolitik olaylar ve tedarik zincirindeki aksamalar, şirketlerin yönetim kurullarının gündemindeki öne çıkan üç riskten ikisi olarak belirleniyor. Küresel alanda hizmet veren şirketler için ikincil bir tedarik zinciri hattı oluşturmak, gelecekteki olası ticari aksaklık risklerini azaltmanın etkin bir yolu olarak görülüyor.",
                            Url = "vr",
                            IsActive = true,
                            Image = "vr.png",
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Categories = context.Categories.Take(2).ToList(),
                            UserId = 1
                        },
                         new Post {
                            Title = "Mercedes, dünya genelinde 250 bin aracı geri çağıracak",
                            Description = "Yaşam",
                            Content = "Almanya Federal Motorlu Taşıtlar Dairesi’ne göre Mercedes-Benz, potansiyel yangın riskine karşı ihtiyati tedbir olarak 37 bini Almanya’da olmak üzere dünya çapında yaklaşık 250 bin aracını geri çağıracak. Geri çağırılacak modeller şunlar: 2023 üretimi AMG GT, C-Serisi, CLE, E-Serisi, EQE, EQS, GLC, S-Serisi ve SL.",
                            Url = "merso",
                            IsActive = true,
                            Image = "merso.png",
                            PublishedOn = DateTime.Now.AddDays(-20),
                            Categories = context.Categories.Take(2).ToList(),
                            UserId = 1
                        },

                        new Post {
                            Title = "Çok çalışmaktan ölebilir misiniz?",
                            Description = "Yaşam",
                            Content = "japon hükümeti, 1994'te aşırı çalışmadan hastalık ve ölümü tanımış ve ölenlerin sayısını 32 olarak açıklamıştı. bu sayı ertesi yıl 76'ya yükseldi ve çalışma bakanlığı karoşinin tanımını yorgunluk ve stresi de içine alacak şekilde genişletti.",
                            Url = "CokCalismak",
                            IsActive = true,
                            Image = "CokCalismak.png",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "iOS 18’den yeni detaylar ortaya çıktı: Tasarım değişiyor",
                            Description = "Teknoloji ",
                            Content = "Apple, bu yılın sonlarına doğru kullanıcılara sunacağı iOS 18’de çok sayıda yapay zeka özelliğine yer vermesi bekleniyor. Yeni iOS sürümünde ana odağın yapay zeka olacağı uzunca bir süredir zaten dillendiriliyordu ve bu, çok da büyük sürpriz olmayacaktır. Öte yandan şimdi de iOS 18'in görsel açıdan da önemli miktarda değişeceği iddia ediliyor.",
                            Url = "ios18",
                            IsActive = true,
                            Image = "ios18.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "Samsung, akıllı yüzüğünü gösterdi: İşte Galaxy Ring tasarımı ve açıklanan özellikler",
                            Description = "Teknoloji ",
                            Content ="Samsung'un en yeni giyilebilir ürünü Galaxy Ring, kalp atış hızı ve uyku izleme gibi sağlık izleme özellikleriyle birlikte çıkacağını ve aynı zamanda kullanıcılara güne hazır olma durumlarını gösteren bir puan verecek. Sensörlerle donatılmış yüzük, kalp atış hızı, solunum hızı, uyku sırasındaki hareket sayısı ve kişinin yatakta uykuya dalması için geçen süre hakkında ölçümler verecek. Ayrıca yüzük, kullanıcıya ne kadar üretken olabileceğini görebileceği bir canlılık puanı (fiziksel ve zihinsel hazırlığa ilişkin toplanan verilerden) verecek. Bu verilere Samsung Health uygulaması üzerinden erişilebilecek.Samsung, Galaxy Ring'e akıllı telefonlarda olduğu gibi temassız ödeme yapma olanağı sağlayacak bir özellik eklemeyi düşündüklerini de söylediGalaxy Ring, akıllı saat takmadan sağlıklarını takip etmek isteyenler için mükemmel bir alternatif olacak. Samsung akıllı yüzüğü bu yılın sonlarında çıkacak.",
                            Url = "samsung-ring",
                            IsActive = true,
                            Image = "samsung-ring.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = " Aracını tamire bıraktı ustayla mahkemelik oldu...",
                            Description = "Yaşam",
                            Content ="Zonguldak'ta yaşayan Gürkay Hepkaya, 2 hafta önce motorda su kaçağı olduğu gerekçesiyle otomobilini, Şaban Özdemiroğlu’nun oto tamirhanesine götürdü. Bir süre sonra otomobilini tamirden alan Hepkaya, arızanın devam ettiğini fark ederek, otomobiliyle tekrar tamirhaneye gitti.İş yerinden ayrılan Hepkaya’yı birkaç gün sonra tanımadığı bir numaradan arayan kişi, otomobilini hatalı park ettiğini söyledi. Konum olarak aracının tamirhanede olmadığını öğrenen Gürkay Hepkaya, tamirhaneye gitti.Aracının arızasının giderilmediğini öğrenen Hepkaya, polis merkezine giderek, Özdemiroğlu'nun otomobilini şahsi işlerinde kullandığını öne sürüp şikayetçi oldu. Hepkaya, polis eşliğinde savcılık talimatıyla otomobilini teslim aldı.",
                            Url = "arac-tamir",
                            IsActive = true,
                            Image = "arac-tamir.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "The Walking Dead'in kaçındığı sahne 11 yıl sonra hayata geçti",
                            Description = "Yaşam",
                            Content ="The Walking Dead serisinin heyecanla beklenen yeni spinoff'u The Ones Who Live'in ilk bölümü gösterime girdiSerinin Dead City ve Daryl Dixon'dan sonraki 6. spinoff'u, CRM helikopteriyle götürülen Rick Grimes ve onu arayan Michonne'un dönüşünü konu alıyor.Çizgi romandaki meşhur an sonunda gerçekleştiThe Walking Dead: The Ones Who Live'in oyuncu kadrosunda rollerini yeniden canlandıran Andrew Lincoln, Danai Gurira ve Pollyanna McIntosh'un yanı sıra yeni isimler Lesley-Ann Brandt, Matthew August Jeffers ve CRM'in Tümgenerali Beale rolünde Lost'un yıldızı Terry O'Quinn yer alıyor.",
                            Url = "the-walking-dead",
                            IsActive = true,
                            Image = "the-walking-dead.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "ABD Box Office verileri: Bob Marley ikinci haftasında da zirvede",
                            Description = "Yaşam ",
                            Content ="Bob Marley: One Love, gösterime girdiği ikinci hafta sonunda 14 milyon dolar hasılat elde ederek ilk gösterimine kıyasla %53'lük bir düşüş yaşadı. Film yurt içinde 71,1 milyon dolar ve dünya genelinde 120 milyon dolar ile gişede sürpriz bir başarı elde etse de 70 milyon dolar maliyetin ve stüdyo bilet satışlarının sadece yaklaşık yarısını alabiliyor, bu nedenle maliyetini karşılayabilmesi için sinemalarda şarkı söylemeye devam etmesi gerekecek.Bob Marley yeni haftanın üç yeni filmine rağmen üst üste ikinci hafta sonunda da listelerin zirvesinde yer aldı. Sony ve Crunchyroll'un anime devam filmi Demon Slayer: Kimetsu no Yaiba - To the Hashira Training elde ettiği 12 milyon dolarla yeni gelenler arasında en iyi performansı göstererek 2. sıraya yerleşti.",
                            Url = "bob-marley",
                            IsActive = true,
                            Image = "bob-marley.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "Oba Makarna'nın halka arzına 3,4 milyon kişi katıldı",
                            Description = "Yaşam",
                            Content ="Ünlü Menkul Değerler'den Kamuyu Aydınlatma Platformu'na (KAP) yapılan açıklamaya göre, şirketin çıkarılmış sermayesinin 407,17 milyon TL’den 479,42 milyon TL’ye çıkarılması nedeniyle ihraç edilen 72,25 milyon TL nominal değerli toplam 72,25 adet C Grubu pay ve mevcut ortaklar Alpinvest Yatırım Gıda Sanayi ve Ticaret A.Ş.’ye ait 12,04 milyon TL nominal değerli 12,04 milyon adet C Grubu pay ile Turkey Pasta Holding Ltd’ye ait 12,04 milyon TL nominal değerli 12,04 milyon adet C Grubu pay halka arz edildi.Şirket paylarının halka arzında 1,00 TL nominal değerli payların halka arz fiyatı 39,24 TL olarak açıklanırken belirlenen halka arz fiyatı ile halka arz büyüklüğü 3,78 milyar TL olarak gerçekleşt",
                            Url = "oba-makarna",
                            IsActive = true,
                            Image = "oba-makarna.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "Elektrikli Fiat Panda Konseptleri Tanıtıldı",
                            Description = "Teknoloji",
                            Content ="Elektrikli otomobil pazarında yaşanan yoğun hareketlilik bu yıl biraz durulmuş gibi gözüküyor. Öte yandan bu araçlar daha yeni yeni erişilebilir, uygun fiyatlara gelmeye başlıyor. Fiat da beş farklı Panda modelini, uygun fiyatlı elektrikli otomobil dönemi başlarken geri getirmeye hazırlanıyor. Bu modellerin konsept tasarımları ortaya çıktı.",
                            Url = "fiatpanda",
                            IsActive = true,
                            Image = "fiatpanda.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "Çift ekranıyla çok dikkat çeken dizüstü bilgisayar modeli ASUS Zenbook DUO Türkiye’de de satışa sunuldu.",
                            Description = "Teknoloji",
                            Content =" elde edilebilen model hakkında Asus Türkiye şunları aktardı: “ASUS, iki adet 14 inç 3K 120 Hz OLED dokunmatik ekrana sahip dünyanın ilk ultra taşınabilir dizüstü bilgisayarı olan devrim niteliğindeki yeni Zenbook DUO (2024) UX8406’yı ülkemizde satışa sundu. Çıkarılabilir tam boyutlu Bluetooth ASUS ErgoSense klavye ve touchpad ile bu inanılmaz cihaz, hareket halindeyken çok yönlülük için kural kitabını yeniden yazan Zenbook DUO, 109.999 TL’lik fiyatıyla ASUS e-store ve Vatan Bilgisayar’da teknoloji tutkunlarını bekliyor. Intel Evo Edition Zenbook DUO, 1,35 kg’lık hafif bir pakette çoklu görev çok yönlülüğünü üstün mobilite ile ustalıkla birleştiriyor. Çift tam boyutlu 3K 120 Hz ASUS Lumina OLED 16:10 ekran, sezgisel ASUS ScreenXpert yazılımı ile kontrol edilen bir dizi çok yönlü kullanıcı modu (Dizüstü Bilgisayar, Çift Ekran, Masaüstü veya Paylaşım) için dikey veya yatay yönlerde kullanılabilen görsel çalışma alanını anında 19,8 inç’e kadar genişletmek için 180° düz bir menteşe ile birleştirilmiş. Şarj edilebilir klavye, görsel çalışma alanının tam olarak kullanılmasını sağlamak için çıkarılabilir veya geleneksel kapaklı dizüstü bilgisayar deneyimi için alt ekrana yerleştirilebilir. ",
                            Url = "asus-zenbook",
                            IsActive = true,
                            Image = "asus-zenbook.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "Elon Musk, Microsoft'u Eleştiri Yağmuruna Tuttu: X Laptop mu Geliyor?",
                            Description = "Teknoloji",
                            Content ="Microsof'un geliştirdiği Windows, Apple haricindeki tüm bilgisayar ve laptoplarda bulunan ve kullanıcıların oldukça memnun olduğu işletim sistemlerinin başında geliyor.Bazen istenmeyen sorunların baş göstediği işletim sistemine dair son yakınan isim de dikkat çekti. Elon Musk, X hesabı üzerinden Microsoft'u eleştirdi.Elon Musk'ın Microsoft Mağduriyeti Windows kurulumu esnasında ilk aşamada bir hesap oluşturulmasının istenmesi bazı kullanıcılar için sorun oluşturabiliyor. Eskiden böyle bir zorunluluk yokken şu an herhangi bir hesap oluşturulmadığı takdirde işleme devam etmek mümkün olmuyor.İnternet bağlantısı kesildiği zaman bu aşama geçilebiliyor fakat kullanıcılar bu zorunluluğun olmasından çok da memnun değil. Aynı durumdan muzdarip olan bir diğer isim de Elon Musk oldu.",
                            Url = "elon-musk-microsoft",
                            IsActive = true,
                            Image = "elon-musk-microsoft.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "Apple'ın Kulaklıklara Kamera Koymayı Planladığı İddia Edildi: Akıllı Gözlük de Ufukta Var!",
                            Description = "Teknoloji",
                            Content ="Mark Gurman tarafından dillendirilen iddiaya göre Apple, AirPods'lar üzerinde de bazı değişiklikler yapmak için uğraşıyor. Bu bağlamda; kaynağımıza göre Apple, AirPods'lara sağlık sensörleri ve kameralar eklemek için de kolları sıvamış durumda. 'B798' olarak kodlanan bu yeni ürün, kullanıcılara akıllı gözlük benzeri bir deneyim sunacak. Üstelik bu yeni nesil AirPods'lar, yapay zekâ destekli bazı özelliklerle donatılacaklar.",
                            Url = "airpods",
                            IsActive = true,
                            Image = "airpods.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "Akıllı saat takmayan akıllı erkeklerin tercihi",
                            Description = "Yaşam",
                            Content ="Swiss made saat markası WAINER, yeni reklam kampanyasını yayınladı. Reklam kampanyasının merkezine akıllı saatlere karşı gerçek saatlerin tarz farkını koyan WAINER; aynı zamanda gerçek saat markalarının öncüsü ve sözcüsü olarak konumlanıyor. WAINER; ürettiği saatlerin her parçasında kusursuz işçiliği ve modern detayları bir araya getiriyor. Marka, yeni reklam kampanyasında kullandığı “Akıllı saat takmayan akıllı erkeklerin tercihi!” sloganıyla birlikte gerçek saat markalarının da sözcülüğü görevini üstleniyor. Gerçek saat tutkunlarının lider ruhlu, kahraman ve tarz sahibi erkekler olduğuna dikkat çeken reklam kampanyasının strateji ve fikir mimarlığı ise M.A.R.K.A. reklam ajansı ve Ajans Başkanı Hulusi Derici’ye ait. ",
                            Url = "saat",
                            IsActive = true,
                            Image = "saat.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },
                        new Post {
                            Title = "İstanbul ve Ankara'da pide fiyatı belli oldu",
                            Description = "Yaşam",
                            Content ="Türkiye Fırıncılar Federasyonu Başkanı Halil İbrahim Balcı, Ankara’da pide 250 gram fiyatı 15 liradan satılacak. İstanbul’da da 250 gram fiyatı 15 liradan satılacak, ilçelerde değişiklik olabilir. Ekmekte fiyat değişikliği söz konusu değil dedi.",
                            Url = "pide",
                            IsActive = true,
                            Image = "pide.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "Almanya'da ihracatçıların hissiyatı toparlandı",
                            Description = "Yaşam",
                            Content ="Ekonomi Araştırma Enstitüsü (ifo) tarafından yapılan anket sonuçlarına göre şubat ayında ifo ihracat beklentileri endeksi bir önceki ay revize edilen -8,4 puan seviyesinden -7 puana yükseldi.ifo Anketler Başkanı Klaus Wohlrabe, 'Alman ihracat ekonomisi mevcut küresel ekonomik gelişmelerden neredeyse hiç yararlanamıyor. Hala geliştirilecek çok yer var' dedi.Ankete göre sadece birkaç sektör ihracatta büyüme beklemeye devam ediyor. Bunlar arasında cam, seramik, yiyecek ve içecek üreticileri bulunuyor.Şu anda olumlu ve olumsuz beklentilerin neredeyse dengede olduğu elektrik-elektronik sektöründe ihracat beklentileri yükseldi. Ancak makine ve ekipman üreticileri arasında beklentiler Haziran 2020'den bu yana en düşük seviyesine geriledi. Otomobil üreticileri de ihracatta devam eden zayıflık yaşıyor. Aynı durum metal sektörü için de geçerli oldu.",
                            Url = "almanya-ihracat",
                            IsActive = true,
                            Image = "almanya-ihracat.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "Survivor'da 'tekmeli' gece yarısı kavgası: Sema diskalifiye mi olacak?",
                            Description = "Gündem",
                            Content ="Bu akşam yayınlanacak yeni bölümde Sema ile Pınar temaslı kavga ediyor. Acun Ilıcalı yine acil durum konseyini topluyor. Kardeşini parkurda göremeyen Seda çok sinirleniyor.Yeni bölümde Acun Ilıcalı Sema'ya verdikleri kararı açıklıyorSurvivor'da Pınar'ın önceki yarışmalardan birinde Sema'ya yönelik fiziki görümüyle ilgili yorumu gece saatlerinde adada kavgaya dönüştü.Yayınlanan fragmanda Sema'nın Pınar'ı ayağıyla tekmelemesi sonrası kavganın büyüdüğü görüldü. Konsey'de ise Sema'nın gözündeki morluk dikkat çekerken Pınar ise ne durumda gösterilmedi.Nefise konseyde 'Pınar sanıp hepimize tekme yumruk savruldu' dedi. Atakan ise 'Ağır bir tahrik vardı Sema'ya' ifadelerini kullandı. ",
                            Url = "survivor-sema",
                            IsActive = true,
                            Image = "survivor-sema.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "Petrolde denge arayışı",
                            Description = "Gündem",
                            Content ="Brent geçen hafta yüzde 2'den fazla kayıp yaşadıktan sonra varil başına 82 dolara düştü; ABD'li mevkidaşı ABD ham petrolü ise 76 doların üzerindeydi. Görünümler bu hafta büyük bir sektör buluşması olan Londra'daki Uluslararası Enerji Haftası'ndan gelecek. Ayrıca ABD enflasyon verileri, Fed’in ne zaman faiz indirimine başlayacağına dair beklentileri şekillendirecek ve enerji talebini ve doların seyrini etkileyecek.Daha geniş piyasalarda ABD para biriminin göstergesi gücünü korurken, bakır dahil çoğu emtia ham petrolle birlikte zayıfladı.Petrol son iki haftadır Orta Doğu'daki gerilimler ve OPEC+'ın ABD dahil grup dışından gelen yüksek üretimin etkisini telafi eden arz kısıtlamaları ile varil başına 3 dolar civarında dar bir bantta işlem gördü. Kartel ve Rusya dahil müttefiklerinin mevcut kesintilerini gelecek ayın başlarında yapacakları toplantıda bir sonraki çeyreğe kadar uzatmaları bekleniyor.",
                            Url = "petrol",
                            IsActive = true,
                            Image = "petrol.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "Asya borsalarında Nikkei rekor tazeledi",
                            Description = "Yaşam",
                            Content ="Japonya'nın Nikkei 225 endeksi, yatırımcıların uzun bir hafta sonundan dönmesiyle Pazartesi günü yeni bir rekora ulaştı. Diğer yandan Çin hisseleri galibiyet serisini sürdürmek için yükselişle açıldı.Japonya'nın Nikkei 225 endeksi yüzde 0,6 yükselerek 39.098,68'lik kapanış rekorunun üzerinde rahat bir şekilde işlem gördü. Endeks ilk kez Perşembe günü 1989'daki tüm zamanların en yüksek seviyesi olan 38.915,87'ye ulaştı.Daha geniş Topix yüzde 0,8 oranında değer kazandı.Yatırımcılar bu hafta Çin'in imalat sanayi satın alma yöneticileri endeksi ve Fed'in tercih ettiği enflasyon göstergesi olan ABD kişisel tüketim harcamaları fiyat endeksi verileri de dahil olmak üzere beklenen bir dizi ekonomik veriye odaklanacak.",
                            Url = "asya-borsa",
                            IsActive = true,
                            Image = "asya-borsa.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "Gladiator 2, tarihin en yüksek maliyetli filmlerinden birisi olacak",
                            Description = "Yaşam",
                            Content ="Tüm zamanların en başarılı filmleri arasında yer alan Gladiator'ın yıllar sonra gelen devam filmi, bu yıl sinemaseverlerle buluşacak. Gladiator, tüm dünyada tanınırlığı olan bir yapım olduğu için devam filminin de izleyicilerden büyük ilgi göreceği düşünülüyor. Bu yüzden Paramount bu filme kayda değer bir yatırım yapmaktan kaçınmadı. Ancak bu hafta gelen bilgiler gösteriyor ki Paramount'un Gladiator 2'ye yaptığı yatırım ilk başta düşündüğümüzden de büyük olabilir. Hatta görünen o ki stüdyonun ilk başta düşündüğünden de fazla olmuş.The Hollywood Reporter tarafından paylaşılan bilgilere göre Gladiator 2'nin 165 milyon dolarlık kayda değer bir bütçeyle çekilmesi planlanıyordu. Ancak prodüksiyonda işler planlandığı gibi gitmeyince, film belirlenen bütçenin çok üstüne çıktı. Öyle ki filmin sadece yapım bütçesinin 310 milyon dolara çıktığı söyleniyor. Eğer THR'ın paylaştığı bu bilgi doğruysa, ki THR gibi bir yayının bu konuda yanılması pek olası değil, Gladitor 2 tarihn en yüksek maliyetli filmlerinden biri olacak demektir.",
                            Url = "gladyator2",
                            IsActive = true,
                            Image = "gladyator2.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "Fatih Terim yönetimindeki Panathinaikos evinde lig sonuncusu Kifisia'dan 1 puan koparabildi",
                            Description = "Gündem",
                            Content ="Ligin 24. haftasında oynanan maçta ev sahibi ekip, 37. dakikada Sebastian Palacios'un golüyle 1-0 öne geçti.Panathinaikos'ta Bart Schenkeveld, 64. dakikada kırmızı kart gördü ve takımını 10 kişi bıraktı. Kifisia, Ivan Milicevic'in 68. dakikada bulduğu golle maçta eşitliği yakaladı ve karşılaşma da 1-1 sona erdi.Bu sonuçla Panathinaikos, puanını 52'e çıkarırken Kifisia ise 17 puanla son sırada kalmaya devam etti.",
                            Url = "fatih-terim",
                            IsActive = true,
                            Image = "fatih-terim.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        },

                        new Post {
                            Title = "ABD, Çin'in 28nm gibi “olgun” üretim teknolojilerine erişimini kısıtlamayacak",
                            Description = "Teknoloji",
                            Content ="ABD İhracat İdaresi Sekreter Yardımcısı Thea D. Rozman Kendler, yaptığı açıklamada ihracat kısıtlamalarını olgun çiplere ya da eski çiplere doğru genişletmek gibi bir niyetlerinin olmadığını belirtti. Dolayısıyla Çin, olgun üretim süreçleriyle (genellikle 28nm veya daha eski olarak tanımlanıyor) üretilen çipleri geliştirecek ekipmanlara ve doğrudan bu çiplere erişebilecek.ABD’nin bu kararının altında aslında kendi çıkarları ve dünyanın bundan olumsuz etkilenmemesi yatıyor. Zira ABD, Çin'de üretilen çiplere halen bağımlı ve tedarik zincirindeki esnekliğin bozulmasından yana değil. Çünkü, bu tip eski teknolojileri kullanan işlemciler veya yongalar, çok geniş çaplı elektronik eşyalarda ve otomotiv sektöründe kullanılıyor. Bu çiplere yönelik bir yaptırım sadece ABD’yi değil diğer bölgelerde de olumsuz etkiler oluşturabilir.",
                            Url = "cip",
                            IsActive = true,
                            Image = "cip.jpg",
                            PublishedOn = DateTime.Now.AddDays(-30),
                            Categories = context.Categories.Take(4).ToList(),
                            UserId = 2
                        }

                    );
                    context.SaveChanges();
                }
            }
        }
    }
}