   M S B A M L   `   `   `  ���� ?  ;PAAK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:USB_Locker
USB_Locker      USB_Locker.MainWindow   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   &localclr-namespace:USB_Locker   -   $��20(�  � AllowsTransparency$
  True��
������  � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � Title$ 
USB Locker��$	��500��$	��900��$��	Helvetica)� � 	Resources  �� Source�� $ ButtonTheme.xaml?�%    .��� .+���  �� CornerRadius$ 10��$��2������ .���  � Color$ #05454C�� � Offset$	 0.0Q�� $ #7B0F65��$ 1Q��� 
������ $��0q�$��10q�	 �� TabStripPlacement$		 Top=� 
 �� 
TargetType �� Property �� Value �� 
TargetType �Name ��Name �� Triggers P� Property P� Value��%  '��       �� "
 ��.���  � ��
 �������  �@J�Opacity$	 0.7Q���  � �� �� " ��.R�� $ Pasel��.+��� $ ContentSite��$��Center=�$��Header��$
��10,2q� P�  �@��
IsSelected$
 True��. ���  �@J�Opacity$ 1Q�.@��� $��General��.���  � ColumnDefinitions �� $	��350 ��� $	��200 ��� $	��350 � � RowDefinitions �� �� .+��� $��Center=�$��1��.+�.  (MahApps.Metro.IconPacks.PackIconMaterial  -     Name$ IconLock��   Kind$ LockOpen=�
���/���$��Center=�$��Center=�$	��150��$	��150��$��	0,30,0,10q��� $��P . A . A . K��$��Light"�$��40(�
�������$��Center=��� $��Center=�$��0��.+��� $��Number of keys:��$��Light"�$��25(�
�������$��Center=��� -    ��Name$ labelKeysCounter��$��0��$��Light"�$��50(�
�������$��Center=��� $��Center=�$��3��.+��� $ ��Number of protected files:��$��Light"�$��25(�
�������$��Center=��� -   $ labelFilesCounter��$��0��$��Light"�$��50(�
�������$��Center=��� $��Center=�$��0��$��1��$��3��.+��� -   $ labelUsername��$��Hello��$��25(�$��Light"�$��0,0,0,20q�$	��Top=�$��Center=��� $��Status:��$��Light"�$��35(�
�������$��Center=��� -   $ labelStatus��$��
Authorized��$��Light"�$��50(�$��Center=�
���/����� $��Devices��.���  �� $	��450 ��� $	��450 � �� $
��auto �.+��� $��0��$��0,50,0,0q�.+��� $��Connected devices:��$��Center=�
��������� -    ��Name$ listBoxConnectedDevices��   _ListBoxItemStyle#���   $	��425��$��0,5,0,5q�$	��200��$��18(��� -    ��Name$ submitButton��$	��100��$��40��$��Select��${�False���� $��1��$��0,50,0,0q�.+��� $ ��Connected trusted devices:��$��Center=�
��������� -	   $ listBoxTrustedDevices��#���   $	��425��$	��200���� -
   $ statusLabel��$��No trusted devices found��$��2��
��� E��$��0,0,0,10q�$��Center=��� -   $ deleteTrustedDeviceBtn��$��Delete��$	��100��$��40���� $��Files��.���� $��0,50,0,0q�.+��� $��Protected files��$��Center=��� -   $ listBoxFiles��#���   $	��800��$	��300��$��	0,10,0,10q�$��18(���  �� Orientation$ 
Horizontal=�$��Center=�.+��� -   $ addFilesBtn��$��	Add files��$��0,0,50,0q�$	��150��$��40���� -   $ deleteFilesBtn��$��Delete files��$	��150��$��40���� $��Folders��.���� $��0,50,0,0q�.+��� $��Protected folders��$��Center=��� -   $ listBoxFolders��#���   $	��800��$	��300��$��	0,10,0,10q�$��18(��� $ 
Horizontal=�$��Center=�.+��� -   $ addFoldersBtn��$��Add folders��$��0,0,50,0q�$	��150��$��40���� -   $ deleteFoldersBtn��$��Delete folders��$	��150��$��40���� $��Factory reset / lost key��.���� $��0, 100, 0, 0q�$��Center=�.+��� $F��@In case you have lost your key, you can recover your files here.��$��Center=��� $ 
Horizontal=�$��0,20,0,0q�$��Center=�.+��� -   $ labelSecurityQuestion��$��	Helvatica)�$��Light"�$��Center=�
�������
������ $��0q�$	��400��$��Center=�$��32��$��20(�$��Security question��  $ CommentQuestion=�$��Center=�$��Center=�
��������� $	��420��$��2��
������� J� Opacity$	 0.5Q��� $ 
Horizontal=�$��0,20,0,0q�$��Center=�.+��� -    ��Name$ textBoxSecurityAnswer��$��	Helvatica)�$��Light"�$��20(�$��Center=�
�������
������ $��0q�$	��400��$��Center=�$	 0.5Q�$��32��$��Security answer��  $
 Text=�$��Center=�$��Center=�
��������� $	��420��$��2��
�������$	 0.5Q��� $ 
Horizontal=�$��0,20,0,0q�$��Center=�.+�G� -    G�Name$ textBoxRecoveryPassword��$��	Helvatica)�$��Light"� G� Password$ Password��$��20(�$��Center=�
�������
������ $��0q�$	��400��$��Center=�$	 0.5Q�$��30�� � Cursor$ IBeam��  $	 Key=�$��Center=�$��Center=�
��������� $	��420��$��2��
�������$	 0.5Q��� -   $ btnRecoverFiles��$��0,20,0,0q�$��Recover files��$	��250��$��50���� -     ��Name$  checkBoxAutoStart��$	��Top=�$��Right=�$��
0,13,100,0q�$��RightToLeft=�.���� $��LeftToRight=�$��
Autostart:��$��Light"�$��20(�
��������� -   $ btnMinimize��$	��Top=�$��Right=�$��	0,10,50,0q�$��30��$��30��.��  $ WindowMinimize=�
��������� -   $ btnExit��$	��Top=�$��Right=�$��	0,10,10,0q�$��30��$��30��.��  $ Close=�
�������