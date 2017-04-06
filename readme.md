# Cache System
This is a cache system written in C# to make cache process easy.

Working with this library is simple and you can set it up in your project with following instructions:

>1.Download or Clone this library.
>2.Add the DLL file to your project using reference section.
>3.Start using library


### Examples

Already there is a built in Example Project Called `CacheTest` inside the project.

But there is a short example that shows how library works

```javascript
 //Creating a new object of cache system and passing 2 parameters, Base path for the cache folder and the name of the cache folder.
            Cache cache = new Cache("C:\\Users\\Shahin\\Desktop", "Images");

            //DownloadFile function automatically checks that if the file is already cached or not,
            //If it's not cached before it will download the file and store it then return the Path of file
            string downloadedFilePath = cache.DownloadFile("https://www.tutorialspoint.com/green/images/logo.png", "7C36F81013CE9E0A169D43DAAF98BD21");
            MessageBox.Show(downloadedFilePath);
```
