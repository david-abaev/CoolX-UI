# CoolX-UI
This is UI Kit for Xamarin. It's include Styles,Setters, Triggers and Behaviors for using in the building Xamarin App (Xamarin.Forms / Xamarin.iOS / Xamarin.Android )

#### To Do
Add Triggers and Behaviors in the next release.

### How to use 

1) Install CoolX-UI package from Nuget. Add using CoolXUI to your *.cs file.
```
using CoolXUI;
```
2) For add new style to visual element you neew write below code: CoolXStyle.GetStyle("coolx classes").

Please note that T must be one of Visual Elements

Example:
```
Label label = new Label{Style = CoolX.GetStyle<Label>("text-color-red;bg-color-blue;text-Welcome to CoolX UI;")};
```
### The Color helper
You can use standart Xamarin colors like:
```
CoolX.GetStyle<T>("text-color-red")
```
Available colors: 

+ accent
+ aqua
+ black
+ blue
+ fuchsia
+ gray
+ green
+ lime
+ maroon
+ navy
+ olive
+ pink
+ purple
+ red
+ silver
+ teal
+ transparent
+ white
+ yellow
+ navy

Also you can use HEX color in the next way:
```
CoolX.GetStyle<T>("text-color-#fff")
```

### If you already have your style and want to add CoolX classes


For more information you can read [documentation](http://coolx-ui.com)
