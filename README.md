# Car Rental Project
![](images/rentalcar.jpg)
### Proje Engin Demiroğ'un Yazılım Geliştirme Kampı süresince kendimizi geliştirmek adına her geçen gün daha da geliştirdiğimiz Car Rental yani Araç Kiralama projesidir.
## Öğrenilen
<ul>
<li>Dependency Injection</li>
<li>SOLID</li>
<li>Web API</li>
<li>Autofac</li>
<li>Fluent Validation</li>
<li>AOP</li>
</ul>

## Dependency Injection
Dependency Injection türkçe anlamıyla Bağımlılık Enjeksiyonu anlamına gelir. Bu teknik SOLID prensiplerinin 5. harfi olaran Dependency Inversion ayağının partneri diyebiliriz. Dependency Injection en basit mantıkla bir nesnenin bağlı olduğu diğer nesnelere ulaşmak için kullanılan bir tekniktir. Neden böyle bir yapıya ihtiyaç duyuyoruz diye sorarsak bağımlılıkları ortadan kaldırmak için diyebiliriz. Bu sayede ise;
<ul>
<li>Gevşek Bağımlı uygulamalar tasarlayabilir(Loosely Coupled)</li>
<li>Uygulama içerisinde değişmesi gereken yerler en aza indirgenebilir yani onlarca yerde değişiklik yapmak yerine tek bir çatıda yapılabilir.</li>
<li>Yazılım Kalite kontrolü sağlanabilir.</li>
</ul>

## SOLID
### Single Responsibility
Single Responsibility en basit manada bir methodun içinde 2 işlem yapılamaz diyebiliriz. Katmanlı mimaride her katmanın bir görevi vardır siz Business katmanınında yazdığınız bir kodu DataAccess katmanında yazamazsınız eğer  yazıyorsanız SOLID prensiplerini çiğniyorsunuz demektir. Her katman,sınıf,method vs. içinde tek bir iş yapılır. Buda bize Clean Code sunar.

### Open Closed
Open Closed en basit manada tak-çıkar mantığı denilebilir. Open sınıfınıza yeni bir şeyler ekleyebilmenizi sağlar. Günü geldiğinde istekler değiştiğinde o isteklere cevap verebilmesi ve buna göre değişiklikler yapılmasını sağlar. Closed ise bir sınıfın temel özelliklerinin kapalı olmasını  yani yeni gelen bir şey yüzünden o sınıfın özelliklerinin değişmemesi anlamını taşır. Yani yazdığınız projeye yeni bir özellik eklenebilmesi ve eklenen özellik ile hiç bir şeyin değişmemesi gerekir.

### Liskov Substitution
Liskov Substitution en basit manada bir şey bir şeye benziyor diye aynı yerde kullanma demektir. Bir banka sistemini düşünün gerçek müşteri ve tüzel müşteriler vardır ama ikisi asla aynı değildir. Gerçek müşterinin TC Kimlik Numarası vardır ancak tüzel müşteriler yani firmaların böyle bir numarası yoktur siz müşteri sınıfında 2 ayrı müşterinin de bilgilerini tuttuğunuzda tüzel müşteride TC Kimlik Numarası kısmı boş geçiceksiniz buda istenilen bir durum asla değildir.

### Interface Segregation
Interface Segregation en basit manada arayüz ayrılma ilkesidir. Bir şirketi düşünün bu şirkette yönetici,işçi ve robotların çalıştığını hayal edin ve bunların her biri bir sınıf olduğunu. Sizin tüm bunların dışında bir interface'iniz olsun ve methodları ise maaş ödeme çalışma ve yemek yeme olsun. Siz eğer bu interface'i hem robota hem yöneticiye hemde işçiye implemente ederseniz ortaya şöyle bir sonuç çıkar;
#### Robot
<ul>
<li>Maaş ödendi</li>
<li>Yemek yendi</li>
<li>Çalışma yapıldı</li>
</ul>

#### Yönetici
<ul>
<li>Maaş ödendi</li>
<li>Yemek yendi</li>
<li>Çalışma yapıldı</li>
</ul>

#### İşçi
<ul>
<li>Maaş ödendi</li>
<li>Yemek yendi</li>
<li>Çalışma yapıldı</li>
</ul>

Bir şeyi fark ettiniz mi robot maaş aldı yemek de yedi hemde çalıştı ancak robot maaş almaz ve yemek yemez öyle dimi ? İşte burada araya Interface Segregation geliyor yani arayüz ayrılma ilkesi. Biz bu yapıyı şöyle yapsak yemek yeme,çalışma ve maaş ödemeyi ayrı ayrı interface yapsak ve bunları ayrı ayrı sınıflara implemente etseydik şöyle bir sonuç çıkardı karşıya;
#### Robot
<ul>
<li>Çalışma yapıldı</li>
</ul>

#### Yönetici
<ul>
<li>Maaş ödendi</li>
<li>Yemek yendi</li>
<li>Çalışma yapıldı</li>
</ul>

#### İşçi
<ul>
<li>Maaş ödendi</li>
<li>Yemek yendi</li>
<li>Çalışma yapıldı</li>
</ul>

Bakın şimdi oldu işte.

### Dependency Inversion
Dependency Inversion bir tasarım desenini kullanır oda yukarıda anlatmış olduğum Dependency Injection'dır. Buna da örnek verecek olursak bir bankayı düşünün 3 ayrı mevzuat hesabı olduğunu düşünün bunları çalıştırırken bir sınıfta 3'ünü de somut haliyle yani new'leyerek çağırıp ilgili fonksiyonu çalıştırmak zorundasınız ancak bunu yapmak yerine siz bir interface oluşturup onların referanslarını tutarsanız Dependency Injection yöntemiyle istenilen mevzuatları somut değilde soyut olarak çağırıp çalıştırabilirsiniz. Bunu yapma sebebimiz ise yarın bir gün farklı bir mevzuat geldiğinde hiç bir şey etkilenmeden yeni gelen mevzuatı da kullanabiliriz.

## Web API
API, Türkçe anlamı “Uygulama Geliştirme Arayüzü” olan “Application Programming Interface” kelimelerinin baş harflerinden meydana gelen bir kelimedir. API sayesinde yazılım geliştiricileri, ellerindeki verileri yada işlevsellikleri istedikleri sınırlılıkta dış dünyayla paylaşabilmekte ve bu paylaşım sürecinde tüm kontrolleri ellerinde tutabilmektedirler.
Web API kullanma ihtiyacı ise şu şekilde ortaya çıkıyor artık günümüzde cep telefon tablet gibi cihazların kullanım artışıyla sadece Web Siteleri yetersiz kalmaktadır bu yüzden Web API ile diğer cihazlardaki kullancı isteklerine de karşılık vermek amacıyla API ihtiyacı ortaya çıkmıştır.

## Autofac
Autofac, .Net için yazılmış bir containerdır ve kullanımı oldukça kolay ve kullanışlıdır. IoC Container yerine kullanılabilir ancak aklımıza şu soru gelebilir zaten .Net'in içinde default olarak var olan bir kullanım varken neden bu gibi Containerlara ihtiyaç duyuyoruz diyebilirsiniz bunu şöyle açıklayabiliriz Autofac bize AOP yapmamızı sağlayan bir yapıdır ve bunun dışında yarın öbür gün farklı servis sağlayıcıları yada farklı API eklendiğini düşünecek olursak var olan yöntem biraz ilkel kalacaktır.

## Fluent Validation
Fluent Validation, veri kuralları kütüphanesidir. Biz burada verilerin doğruluğunu teyit etmek için kullandığımız bir kütüphanedir. Daha açıklayıcı anlatıcak olursak tek bir çatı altında doğrulama kurallarını yazmamızı sağlar ve oldukça güvenlidir. Ancak çoğu insan iş kuralları ile doğrulama kurallarını karıştırır ikisinin arasındaki en temel fark doğrulama kuralları o verinin yapısıyla ilgilenir ancak iş kuralları yapıyla ilgilenmez iş kuralları örnek verecek olursak birine ehliyet verirken yazılı sınavdan geçti mi ? test sürüşünden geçti mi ? gibi soruların olduğu kurallardır doğrulama kuralları ise bir veri eklendiğini düşünün minumum 10 karakter gibi kuralların olduğu kısımdır.

## AOP(Aspect Oriented Programming)
Türkçe anlamıyla Cephe Yönelimli Programlama anlamına gelir. Neden böyle bir teknolojiye ihtiyaç duyarız diyorsanız bunun sebebi ise şudur yazılım geliştirmede bazı bileşenler Croos Cutting Concerns yani uygulamayı dikine kesen ilgi alanları diyebiliriz, loglama,cache,doğrulama,performans yönetimi gibi bütün katmanlarda farklı katmanlarda bunları yapabiliyoruz yani AOP sayesinde Aspect kullanarak Attribute'ler ile kullanılabilir hale getiriyoruz.

