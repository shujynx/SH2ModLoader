# How to install

## Downloading BepInEx

First, head on over to [this link](https://builds.bepinex.dev/projects/bepinex_be) (https://builds.bepinex.dev/projects/bepinex_be) to obtain BepInEx, then click the down arrow on the rightmost side of the latest "artifact".  
  
![](https://cdn.discordapp.com/attachments/377899265424621569/1013220073189671033/unknown.png)  
  
This will now open up a list of zip files, download the zip file labeled as "**BepInEx Unity (IL2CPP) for Windows (x64) games**".  
![](https://cdn.discordapp.com/attachments/377899265424621569/1013220151572840478/unknown.png)  
  
Next, go to the root of your Soul Hackers 2 game files, to get there, right click the game on your Steam library, and then select Manage -> Browse Local Files.  
![](https://cdn.discordapp.com/attachments/377899265424621569/1013220939917430794/unknown.png)  
  
Now extract the contents of the BepInEx zip file you downloaded on the root of your game install directory, your game folder should now look something like this.  
![](https://cdn.discordapp.com/attachments/377899265424621569/1013205547669000192/unknown.png)  
Make sure you now have a BepInEx folder, a dotnet folder and a file called winhttp.dll, if any or all of these are missing, it means you extracted the files to the wrong place!  
  

##  First time BepInEx setup

  
Now that you have extracted BepInEx into the correct directory, **go inside the BepInEx folder**, and create a plugins folder if it does not already exist.  
Download the mod zip file appended at the end of this post, extract the zip file, and place the extracted SoulHackers2ModLoader.dll file inside this folder.  
  
![](https://cdn.discordapp.com/attachments/377899265424621569/1013223598607061023/unknown.png)  
  
With the setup now finally done, boot your game once, note, THE GAME WILL TAKE LONGER THAN USUAL TO BOOT NOW, THIS IS COMPLETELY NORMAL.  
  
Once your game is finally done booting after a while, close the game and we can finally move into the final step.  
  
**Configuring BepInEx**  
  
Open the BepInEx folder, and inside it, you should see a config folder, open that folder and inside you will now see 2 .cfg files, which can be edited with any text editor of your choice (like notepad++).  
  
(Note, for some people these configuration files might not being generated after the first long boot, just relaunch your game a second time and then close it again, and it should be good).  
![](https://cdn.discordapp.com/attachments/377899265424621569/1013226115147505794/unknown.png)  
  
Open BepInEx.cfg, find the setting named UnityLogListening and set it to _false,_ if you dont do this, BepInEx will NOT work with Soul Hackers 2!  
![](https://cdn.discordapp.com/attachments/1012809823630401608/1013206816764723230/unknown.png)    
And with that, you're finally done with the setup!  
You are now free to boot and play your game and enjoy your DLC outfits outside of battle.

    Original guide written by DeathChaos
