   M S B A M L   `   `   `  ����E  AUSB_Locker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:USB_Locker
USB_Locker  5   	       USB_Locker.logonScreen   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   *localclr-namespace:USB_Locker     5   	   c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   5   	   -   5          � Title$  logonScreen��5	   	   $	��450��6   $	��380��6*    � AllowsTransparency$
 True��5
   	   
������  � WindowStyle$
 None=�5   	    � 
ResizeMode$ NoResize=�6    � 	Resources 5       �� Source�� 5   
   $ ButtonTheme.xaml?�6   %    .��5      � .+�5   
   �  � RowDefinitions 5      �� 5      �� 5      .+�5      ��  �� CornerRadius$ 10��6   $��2��6'   ��5      �� 5      .��5      �  � Color$ #05454C��6'   	 � Offset$		 0.0Q�67   � 5      $ #7B0F65��6'   $	 1Q�67   5      5      �� 5       -   5        
 ��Name$
 btnMin��5       $	��Top=�6%   $��Right=�6=   $��	0,10,50,0q�5!      $��30��6(   $��30��64   .��5"      .  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ WindowMinimize=�6-   
�������6C   5#      �� 5%      -   5        $
 btnExit��5%      $	��Top=�6&   $��Right=�6>   $��	0,10,10,0q�5&      $��30��6(   $��30��64   .��5'        $ Close=�6-   
�������6:   5(      �� 5*      $��Center=�6   .+�5+        $
 Lock=�6-   
�������$��Center=�5,   -   $��Center=�5-   -   $	��100��5.   -   $	��100��6:   $��0,0,0,10q�5/   -   �� 50      $��P . A . A . K��6   $��Light"�51      $��	Helvetica)�52      $��22(�53      
�������$��Center=�55      56      �� 58      $��1��6   .+�59      ��  �� Orientation$ 
Horizontal=�6   .+�5:      �� -   5         ��Name$ textBoxUsername��5:      $��	Helvatica)�5;      $��Light"�5<      $��Username��5=      $��20(�5>      $��Center=�5?      
�������
������ $��0q�5B      $	��235��5C      $
��Left=�5D       J� Opacity$	 0.5Q�5E      $��30��5F      $��63,0,0,0q�5G      6V     5H      $ Account=�61   $��Center=�5I   "   $��Center=�5J   "   
�������5K   "   5L      �� 5M      $	��250��6   $��2��5N      
�������$	 0.5Q�5P      �� 5R      $ 
Horizontal=�6   $��0,20,0,0q�66   .+�5S      G� -   5         G�Name$ textBoxPassword��5S   "   $��	Helvatica)�5T      $��Light"�5U       G� Password$ Password��5V      $��20(�5W      $��Center=�5X      
�������
������ $��0q�5[      $	��235��5\      $
��Left=�5]      $	 0.5Q�5^      $��30��5_      $��63,0,0,0q�5`       � Cursor$ IBeam��6z     5a      $	 Key=�61   $��Center=�5b   "   $��Center=�5c   "   
�������5d   "   5e      �� 5f      $	��250��6   $��2��5g      
�������$	 0.5Q�5i      �� 5k      $ 
Horizontal=�6   $��0,50,0,0q�66   .+�5l      �� -   5        $
 btnLogin��5l      $	��120��6/   $��40��6;   $��LOGIN��6G   $��	60,0,20,0q�6W   6j   �� 5m      -   5        $
 btnRegister��5m      $	��120��62   $��40��6>   $��REGISTER��6J   6]   5n      5p      5q      5r      5s      