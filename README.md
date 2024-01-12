# StajTakipUygulaması
1. Proje Amacı

  Projemiz bilgisayar mühendisliği bölümü yazılım donanım ve iş yeri eğitimi stajlarının 
bir sistem aracılığı ile başvuruların alınması, dosya yükleme işlemlerinin yapılması, bölüm 
içindeki tüm öğrencilerin staj takibinin yapılması gibi amaca hizmet etmektedir. 
Ana hedef hem öğrencilerin başvuru ve sonrasında yaşadıkları sorunları çözmek ve 
dosya takibini sağlamak diğer yandan görevli akademisyenlerin öğrencilerin bu stajlarını takip 
etmek ve yönetmek gibi işlemlerin yapılmasını sağlamaktadır. Bu amaçların haricinde SOLİD 
prensiplerine bağlı kalmak ve clean code geliştirmek te birincil hedefimiz olmuştur.

  2. Proje Mimarisi
     
Projemizde N katmanlı mimari yapısı kullanılmıştır. Bu mimari ile tüm işlemler 4 katmana 
ayrılmıştır. Bunlar gerekli entitylerin tutulduğu entity layer(katman), daha sonra veri tabanı 
crud işlemlerinin olduğu ve veri tabanı bağlantısının yapıldığı DataContext layer(katman), bir 
diğer katman gerekli validasyon kontrollerinin olduğu, manage ve servicelerin bulunduğu 
Business Layer(katman) ‘dır. Son olarak sistemin kullanıcı ile haberleşmesini sağlayan aynı 
zamanda işlemlerini yapmasına olanak sağlayan sistemin UI katmanı vardır. Bu 4 katman ile 
işler daha hızlı, performansı yüksek ve düzenli bir sistem oluşturulmuştur.

3. Projede Kullanılan Patternler
   
MVC patterni ile projenin UI katmanındaki işlemleri controller, view ve model yapıları 
ile sağlamış olduk. Bu pattern ile hem güncel hem de düzenli kod ile hem SOLİD prensiplerini 
yakalamış olduk. 
Repossitory patterni ile sistemde çalışan ve veri tabanı ile işlemleri olan sınıf ve 
metodları hem generic hem de self repossitory ile tasarladık. Generic repossitory de temel 
olan add, delete, update ve list gibi işlemler yazılırken self repositoryde sadece o entity veya 
tabloda kullanılacak metodlar yazılmıştır.
Adapter pattern ile farklı 2 katmandaki interfaceleri UI katmanındaki controllerlarda 
kullanarak kod tekrarını engellerken daha performanslı bir sistem ortaya çıkarmış olduk. 
Bu patternlerin haricinde sistemimizde FluentValidation, Pagedlist, Mailkit ve AutoMapper 
gibi pekteler kullanılmıştır.

![image](https://github.com/SerdarYuksek/StajTakipUygulamas-/assets/129522255/49bc9547-15e8-48e8-9005-91a39e68c5b3)
![image](https://github.com/SerdarYuksek/StajTakipUygulamas-/assets/129522255/84443845-6ac6-46be-92ac-0ba1cbd2575d)
![image](https://github.com/SerdarYuksek/StajTakipUygulamas-/assets/129522255/5e374dea-03da-47a6-a42e-6b478d4c8442)

