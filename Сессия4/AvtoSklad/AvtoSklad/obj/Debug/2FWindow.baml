   M S B A M L   `   `   `  ����D  @AvtoSklad, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null%clr-namespace:AvtoSklad	AvtoSklad  5   	       AvtoSklad._2FWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   )localclr-namespace:AvtoSklad     5   	     � Title$F  @Окно двухфакторной аутентификации��5	   	   $	��400��5
   	   $	��550��6    � WindowStartupLocation$ CenterScreen=�5   	    � 
ResizeMode$ NoResize=�5   	   ���	#FFE6E6FA � 	Resources 5   
      ModernButtonTheme �� 
TargetType �� Property �� Value �� 
TargetType ��Name	 �� CornerRadius
 �� Triggers P� Property P� Value��%�  &	        �� 5      " ��6.   .�5      ��  � �� �#8000806/   �� 5       � ��
 �����6/   �� 5       � ��$ 24(�6-   �� 5       � ��$
 Bold"�6/   �� 5       � ��$ Italic$�6.   �� 5       � ��$ 0q�64   �� 5       � ��$ 10q�6,   �� 5       � �� 5      �� 5      " ��6*   .R�5      �� $ border��6%   #��z��5   !   $	 10��5    !   $��0q�5!   !   ._�5"   "   �� $��Center=�63   $��Center=�6P   5#      
 5$      P� 5%   "    �@J�IsMouseOver . . �5&   &   ��  � �� �#4B00826C   5(   #   5*      5,      5-      5.      .��50   
   � ��52      �� 53       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 1,1&�67   .��54      �  � Color$ 	#FFE6E6FA��6#    � Offset$ 0Q�65   � 56      $ 	#FFD8BFD8��6#   $ 1Q�65   58      .+�5<      �� $+��%Введите ваш 2FA токен:��6   $
��Left=�5=      $��	50,95,0,0q�5>      $	��Top=�5?      $
��Bold"�5@      $��Italic$�5A      $��24(�5B      ���#4B00825C      �� 5G      -   5         ��Name$ 
SecretWord��5G      $��Center=�5H       �� TextWrapping$
 Wrap=�5I      $��Center=�5J      $	��450��5K      $��40��5L      $��18(�5M      ���#800080$��2q�5O      $��5q�5P      ���	#FFF8F8FF5Q      �� 5U      -   5         ��Name$ Author��5U      #��[  5V      $��Вход��5W      $��Center=�5X      $��	0,280,0,0q�5Y      $	��Top=�5Z      $��36(�5[      $	��450��5\      $��60��5]      5^      5_      5`      