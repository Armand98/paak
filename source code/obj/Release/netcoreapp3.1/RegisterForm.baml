   M S B A M L   `   `   `  ���� ?  ;PAAK, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null'clr-namespace:USB_Locker
USB_Locker      USB_Locker.RegisterForm   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     @d2http://schemas.microsoft.com/expression/blend/2008     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     *localclr-namespace:USB_Locker     c _MahApps.Metro.IconPacks.Core, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137ag cMahApps.Metro.IconPacks.Material, Version=4.0.0.0, Culture=neutral, PublicKeyToken=0c0d510f9915137a?	iconPacks-http://metro.mahapps.com/winfx/xaml/iconpacks   -     � Title$  logonScreen��$	��570��$	��430�� � AllowsTransparency$
 True��
������  � WindowStyle$
 None=� � 
ResizeMode$ NoResize=� � 	Resources  �� Source�� $ ButtonTheme.xaml?�%    .��� .+��  � RowDefinitions �� $��* ��� $��5* �.+���  �� CornerRadius$ 10��$��2������ .���  � Color$ #05454C��	 � Offset$		 0.0Q�� $ #7B0F65��$	 1Q��� -   
 ��Name$
 btnExit��$	��Top=�$��Right=�$��	0,10,10,0q�$��30��$��30��.��.  (MahApps.Metro.IconPacks.PackIconMaterial     Kind$ Close=�
��������� $��Center=�.+��� $��Register Form��$��Light"�$��	Helvetica)�$��22(�
�������$��Center=��� $��1��.+���  �� Orientation$ 
Horizontal=�.+��� -    ��Name$ textBoxFirstName��$��	Helvatica)�$��Light"�$��
First name��$��20(�$��Center=�
�������
������ $��0q�$	��285��$
��Left=� J� Opacity$	 0.5Q�$��30��$��63,0,0,0q�  $ Account=�$��Center=�$��Center=�
��������� $	��300��$��2��
�������$	 0.5Q��� $ 
Horizontal=�$��0,20,0,0q�.+��� -   $ textBoxLastName��$��	Helvatica)�$��Light"�$��	Last name��$��20(�$��Center=�
�������
������ $��0q�$	��285��$
��Left=�$	 0.5Q�$��30��$��63,0,0,0q�  $ Account=�$��Center=�$��Center=�
��������� $	��300��$��2��
�������$	 0.5Q��� $ 
Horizontal=�$��0,20,0,0q�.+��� -   $ textBoxUsername��$��	Helvatica)�$��Light"�$��Username��$��20(�$��Center=�
�������
������ $��0q�$	��285��$
��Left=�$	 0.5Q�$��30��$��63,0,0,0q�  $ Account=�$��Center=�$��Center=�
��������� $	��300��$��2��
�������$	 0.5Q��� $ 
Horizontal=�$��0,20,0,0q�.+�G� -    G�Name$ textBoxPassword��$��	Helvatica)�$��Light"� G� Password$ Password��$��20(�$��Center=�
�������
������ $��0q�$	��285��$
��Left=�$	 0.5Q�$��30��$��63,0,0,0q�  $	 Key=�$��Center=�$��Center=�
��������� $	��300��$��2��
�������$	 0.5Q��� $ 
Horizontal=�$��0,20,0,0q�.+��� -   $ textBoxBirthday��$��	Helvatica)�$��Light"�$��Birthday: day-month-year��$��20(�$��Center=�
�������
������ $��0q�$	��285��$
��Left=�$	 0.5Q�$��30��$��63,0,0,0q�  $ Calendar=�$��Center=�$��Center=�
��������� $	��300��$��2��
�������$	 0.5Q��� $ 
Horizontal=�$��0,20,0,0q�.+��� -    ��Name$ comboBoxQuestion��$��	Helvatica)�$��Light"�$��Center=�
�������
������ $��0q�$	��275��$
��Left=�$	 0.5Q�$��35��$��	63,0,10,0q� �� SelectedIndex$ 0��$��20(�.@��� .���� $��What is your dog's breed?���� .���� $"��What is your favourite food?���� .���� $(��"What is your mother's maiden name?��  $ CommentQuestion=�$��Center=�$��Center=�
��������� $ 
Horizontal=�$��0,20,0,0q�.+��� -	   $ textBoxAnswer��$��	Helvatica)�$��Light"�$��Answer��$��20(�$��Center=�
�������
������ $��0q�$	��285��$
��Left=�$	 0.5Q�$��30��$��63,0,0,0q�  $
 Text=�$��Center=�$��Center=�
��������� $	��300��$��2��
�������$	 0.5Q��� -
   $
 btnCreateAnAccount��$	��200��$��40��$��CREATE AN ACCOUNT��$��
60,40,60,0q�