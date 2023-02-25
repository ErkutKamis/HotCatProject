HotCat Restaurant Projesi

Projemizde 4 katman bulunmaktadır.

APPLICATION , DOMAIN , INSFRASTRUCTURE , PRESENTATION

APPLICATION KATMANI

Bu katman , uygulamamızdaki iş mantığını içeren kodları içeriyor.Uygulama işlemlerinin gerçekleştirdiğimiz , model sınıflarının , servislerin ve doğrualama(validation)
kurallarının bulunduğu klasörler bu katman içerisinde yer alıyor.

   * Services klasörü iş mantığını yürüten servis sınıflarımızı içeren klasörümüzdür.
   * Validation kullanıcı girdilerinin doğruluğunu kontrol eden doğrulama kurallarını içerir.
   * Automapper veritabanı modelleriyle iş mantığı modelleri arasında veri eşleştirmesi sağlayan bir kütüphanedir..

DOMAIN KATMANI

Bu katman , uygulamamızın işletme mantığının birinci elden tanımlandığı kodların bulunduğu katmandır.Domain katmanı iş süreçlerinin birbiriyle nasıl ilişkilendirildiğini belirleyen interfaceleri içerir.Ayrıca bu katman , uygulamamızın verilerinin nasıl depolanacağını belirleyen repositoryleri ve UnitofWork tasarım desenlerini ile de ilgilidir. 

   * Concrete klasörümüz , uygulamamızın somut sınıfları içerir. 
   * Enums bu klasörümüzde proje boyunca kullanılan enum'lar burada yer alır.
   * Repositories uygulamamızın veritabanı işlemlerini yöneten repository sınıflarını içerir.. 
   * UnitofWork ise repository sınıflarını ve iş mantığını bir arada kullanabilmemizi sağlayan bir tasarım deseni içeren klasördür.
   * Interface uygulamamızın kullanacağı interface'leri içeren kodlarını içeren klasörümüzdür.


INFRASTRUCTURE KATMANI

Bu katman , uygulamamızın alt yapısını sağlayan kodları içeriyor.Veritabanı işlemleri , dependency injection , caching gibi işlemlerle ilgilenen katmanımızdır.

   * Context klasörümüzde veritabanı bağlantısını yöneten DbContext sınıfı burada yer alır.
   * DependencyResolver , Bağımlılık çözümlemesi (dependency injection) işlemlerini yöneten sınıfları içerir. 
   * Mapping klasörümüzde AutoMapper kütüphanesi için veri eşleştirme konfigürasyonlarını içerir.
   * Migration veritabanı tablolarında yapılan değişiklikleri takip eden veritabanı migrasyon sınıflarını içeren klasörümüz.
   * SeedData veritabanına başlangıç verileri eklemek için kullanılan sınıfların bulunduğu klasörümüzdür.
   * Utils bu klasörümüzde ise uygulamamızda genel amaçlı yardımcı sınıfları içeren klasördür.

PRESENTATION KATMANI

Bu katman , uygulamamızın kullanıcı arayüzü ile etkileşimini yöneten kodları içerir.Bu katmanda , kullanıcıların uygulamamızda nasıl etkileşime geçeceği belirlenir.Bu katmanın altında farklı işlevlere sahip olan kontroller(Controller) ve alanlar(Areas) bulunuyor.

   * Areas bu klasör , uygulamamızda farklı işlevlere sahip olan alanlar (Area) içeriyor.
   * Controllers uygulamamızın kontroller'ini (Controller) içeren klasörümüzdür.Bu sınıflar kullanıcıların uygulamamızla olan etkileşimini yönetiyor.
   * Purchase kullanıcıların satın alma işlemlerini yöneten sınıflarımızı içeriyor.
   * Waiter kullanıcıların garsonlarla etkileşimini yöneten sınıflarımızı içeriyor.


Erkut Kamış  - Teşekkürler