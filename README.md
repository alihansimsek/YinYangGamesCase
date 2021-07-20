# YinYangGamesCase

YinYangGames için geliştirilen unity3D ve webApp projesi.

YinYangGamesWebApp servisi gelen kayıt isteklerini player.txt adlı dosyada D:/player.txt pathinde saklıyor. eğer bilgisayarda D:/ mevcut değilse kodda değiştirilmesi gerekir.

Unity3D'de servis çağırısı prototiplemek için geliştirildi. bu yüzden oyundaki juicyness veya fun elementleri üzerine düşmedim. ayrıca backend servisin kullanıcı
skorlarını saklamasındaki tutarlılığı üzerinde de durmadım. normal şartlarda bir DB kullanılacağı için player.txt düzenini göz ardı ettim.

Oyun başlarken GameManager'da verilen playerID'ye göre servisten GET çağrısı ile o oyuncunun son skoru çekiliyor.
Oyuncu ekrana tıklayıp toplarla hedeflere her vurduğunda skor artıyor ve POST çağrısı ile skor servis tarafından txt dosyasına kaydediliyor.

---------------------------------------------

A unity3D and webApp project developed for YinYangGames.

YinYangGamesWebApp service saves incoming requests at the path D:/player.txt. If the path is unavailable, the path in the code should be modified accordingly.

The main purpose of this project was prototyping service calls from Unity3D. So juicyness of the game and fun mechanics are ignored. Also, the backend service
consistency at saving player scores is not developed according to best-practices. Normally a database would be involved, so no further developing poured into
organizing the text-based solution I have now.

When the game starts, it makes a GET call to the service to get player score according to the ID given in the GameManager public field. Every time the player hits
targets with balls by clicking on the screen, a POST request will be sent to save the new score on the text file by the service.
