   M S B A M L   `   `   `  ����D  @AvtoSklad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AvtoSklad	AvtoSklad  5   	       AvtoSklad.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:AvtoSklad     5   	     � Title$%  Окно авторизации��5   	   $	��400��6"   $	��550��6/    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	   ���	#FFE6E6FA � 	Resources 5         ModernButtonTheme �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value��%�  &	        �� 5   
   " ��6*   .�5      ��  � �� �#9370DB6+   �� 5       � ��
 �����6+   �� 5       � ��$ 24(�6)   �� 5       � ��$
 Bold"�6+   �� 5       � ��$ Italic$�6*   �� 5       � ��$ 0q�60   �� 5       � ��$ 10q�6(   �� 5       � �� 5      �� 5      " ��6&   .R�5      �� $ border��6!   #��z��5   !   $	 10��5   !   $��0q�5   !   ._�5       �� $��Center=�6/   $��Center=�6L   5!      
 5"      P� 5#       �@J�IsMouseOver . . �5$   "   ��  � �� �#7B68EE6?   5&      5(      5*      5+      5,      .��5.      � ��50   
   �� 51       �� 
StartPoint$	 0,0&�6"    �� EndPoint$	 1,1&�63   .��52      �  � Color$ 	#FFE6E6FA��6    � Offset$ 0Q�61   � 54      $ 	#FFD8BFD8��6   $ 1Q�61   56      .+�5:   
   �� $��Авторизация��6   $��Center=�5;      $��0,30,0,0q�5<      $	��Top=�5=      $
��Bold"�5>      $��Italic$�5?      $��36(�5@      ���#4B00825A      �� 5E   
   $��Логин:��6   $
��Left=�5F      $��
50,100,0,0q�5G      $	��Top=�5H      $
��Bold"�5I      $��Italic$�5J      $��24(�5K      ���#4B00825L      �� 5O   
   -   5         ��Name$ lg��5O      $
��Left=�5P      $��170,110,0,0q�5Q       �� TextWrapping$
 Wrap=�5R      $	��Top=�5S      $	��330��5T      $��40��5U      $��18(�5V      ���#9370DB$��2q�5X      $��5q�5Y      ���	#FFF8F8FF5Z      �� 5^      $��Пароль:��6   $
��Left=�5_      $��
50,180,0,0q�5`      $	��Top=�5a      $
��Bold"�5b      $��Italic$�5c      $��24(�5d      ���#4B00825e      G� 5h      -   5         G�Name$ pr��5h      $
��Left=�5i      $��170,190,0,0q�5j      $	��Top=�5k      $	��330��5l      $��40��5m      $��18(�5n      ���#9370DB$��2q�5p      $��5q�5q      ���	#FFF8F8FF5r      �� 5v      -   5         ��Name$
 Next��5v      $��Вход��5w      #��[  5x      $��Center=�5y      $��	0,280,0,0q�5z      $	��Top=�5{      $	��450��5|      $��60��5}      5~      5      5�      