   M S B A M L   `   `   `  ���� ?  ;PAAK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:USB_Locker
USB_Locker      USB_Locker.logonScreen   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:USB_Locker     c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   -     � Title$  logonScreen��$	��450��$	��380�� � AllowsTransparency$
 True��
������  � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � 	Resources  �� Source�� $ ButtonTheme.xaml?�%    .��� .+��  � RowDefinitions �� �� .+���  �� CornerRadius$ 10��$��2������ .���  � Color$ #05454C��	 � Offset$		 0.0Q�� $ #7B0F65��$	 1Q��� -   
 ��Name$
 btnMin��$	��Top=�$��Right=�$��	0,10,50,0q�$��30��$��30��.��.  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ WindowMinimize=�
��������� -   $
 btnExit��$	��Top=�$��Right=�$��	0,10,10,0q�$��30��$��30��.��  $ Close=�
��������� $��Center=�.+�  $
 Lock=�
�������$��Center=�$��Center=�$	��100��$	��100��$��0,0,0,10q��� $��P . A . A . K��$��Light"�$��	Helvetica)�$��22(�
�������$��Center=��� $��1��.+���  �� Orientation$ 
Horizontal=�.+��� -    ��Name$ textBoxUsername��$��	Helvatica)�$��Light"�$��Username��$��20(�$��Center=�
�������
������ $��0q�$	��235��$
��Left=� J� Opacity$	 0.5Q�$��30��$��63,0,0,0q�  $ Account=�$��Center=�$��Center=�
��������� $	��250��$��2��
�������$	 0.5Q��� $ 
Horizontal=�$��0,20,0,0q�.+�G� -    G�Name$ textBoxPassword��$��	Helvatica)�$��Light"� G� Password$ Password��$��20(�$��Center=�
�������
������ $��0q�$	��235��$
��Left=�$	 0.5Q�$��30��$��63,0,0,0q� � Cursor$ IBeam��  $	 Key=�$��Center=�$��Center=�
��������� $	��250��$��2��
�������$	 0.5Q��� $ 
Horizontal=�$��0,50,0,0q�.+��� -   $
 btnLogin��$	��120��$��40��$��LOGIN��$��	60,0,20,0q��� -   $
 btnRegister��$	��120��$��40��$��REGISTER��