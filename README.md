# :calling: OneSignal Notification Setup (Unity + Firebase + Android)
---
## :white_check_mark: 1. Create Unity Project & Firebase Setup
1. Create a new **Unity project**.
2. Switch platform to **Android**:
   `File → Build Settings → Android → Switch Platform`.
---
## :fire: 2. Firebase Console Setup
3. Go to [Firebase Console](https://console.firebase.google.com/) and create a new project.
4. In Firebase Console:
   `Project Settings → Service Accounts → Generate New Private Key`.
5. After clicking, a `.json` file will be downloaded automatically. **Keep it safe.**
---
## :rocket: 3. OneSignal Console Setup
6. Go to [OneSignal Console](https://onesignal.com/) and **log in**.
7. Click **"New App/Website"** and:
   - Enter your **App Name**
   - Add Organization (optional)
   - Select **Google Android (FCM)**
   - Click **Next: Configure Your Platform**
8. Upload the **`.json` file** you got from Firebase.
   Click **Save & Continue**.
9. Select **Unity** as your platform and click **Save & Continue**.
10. Click **Done**.
---
## :package: 4. Unity SDK Setup
11. Download OneSignal Unity SDK from Asset Store:
    [OneSignal Unity SDK](https://assetstore.unity.com/packages/add-ons/services/billing/onesignal-sdk-193316)
12. Import the downloaded SDK into your Unity project.
13. In Unity:
    Go to `Window → OneSignal SDK Setup`
    Click **Run All Steps**.
---
## :brain: 5. OneSignal Manager Script
14. Create an **empty GameObject** and name it `OneSignalManager`.
    Attach the script from the link below:
:link: [OneSignalNotification.cs Script](https://pastebin.com/raw/X3PMbWHg)
---
## :wrench: 6. Add App ID in Inspector
15. In Unity, select your `OneSignalManager` GameObject and paste your App ID in the inspector.
   To get App ID:
   - Go to **OneSignal Dashboard → Settings**
   - Click **Keys & IDs**
   - Copy the **App ID** and paste it in Unity.
16. After that, resolve dependencies again:
    `Assets → External Dependency Manager → Android Resolver → Resolve`.
17. Make a build and test it on your Android device.
---
## :bell: 7. Sending Push Notifications
18. In OneSignal Console:
   - Click **Messages** → **Push** → **New Push**
   - Add content and send notifications to test.
---
OneSignalOneSignal
Customer Engagement Platform for Email, Push Notifications, & SMS
The world's leader for mobile push notifications, web push, SMS, email and in-app messaging. Trusted by 2 million+ businesses to send 12 billion+ messages per… (53 kB)
https://onesignal.com/

Unity Asset StoreUnity Asset Store
OneSignal SDK | Services | Unity Asset Store
Get the OneSignal SDK package from OneSignal and speed up your game development process. Find this & other Services options on the Unity Asset Store. (893 kB)
https://assetstore.unity.com/packages/add-ons/services/billing/onesignal-sdk-193316
