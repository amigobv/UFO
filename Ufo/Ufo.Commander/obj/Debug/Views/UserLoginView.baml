   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   H DUfo.Commander, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Ufo.Commander.ResourcesUfo.Commander.Resources 5	   	   9!clr-namespace:Ufo.Commander.ViewsUfo.Commander.Views 5
   	   '   !Ufo.Commander.Views.UserLoginView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5   	   h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5      0sys&clr-namespace:System;assembly=mscorlib  5   	   0resx%clr-namespace:Ufo.Commander.Resources  5	   	   -local!clr-namespace:Ufo.Commander.Views  5
   	     � Title$  Login��5   	   $	��250��6   $	��350��6$   .��5      �� .  (System.Windows.Interactivity.Interaction   	Behaviors 5   
   ?  9Microsoft.Expression.Interactivity.Core.DataStateBehavior  5         Value$
 True��5         	TrueState$ 
ValidState��5         
FalseState$ InvalidState��5         Binding 5   #   �� *	IsValid+5      '  !System.Windows.VisualStateManager   VisualStateGroups 5   
   %  System.Windows.VisualStateGroup  5      -   5        ValidationSummaryStates��   States. 5         System.Windows.VisualState  -   5        
ValidState��   
Storyboard. 5      �� .��5      T� 	 �� TargetProperty$	 (UIElement.Visibility)�68   
 �� 
TargetName$
 ValidSummaryContainer��5      ..�5      i�  R� KeyTime$ 0��65    R� Value 5   "     System.Windows.Visibility 5   &   Visible=�6:   5      5      U� 5       $	 (UIElement.Opacity)�68   $
 BackgroundOverlayBorder��5!      .\�5"      9  3System.Windows.Media.Animation.EasingDoubleKeyFrame   O� KeyTime$ 0:0:1��63    O� Value$	 0.5Q�5#        5$      $ 0:0:2��63   $ 0Q�5%      5&      5'      5(        5)      -   5        InvalidState��. 5*      �� .��5+      T� $	 (UIElement.Visibility)�68   $
 ErrorsSummaryContainer��5,      ..�5-      i� $ 0��65    5.   "    5/   &   Visible=�6:   51      52      U� 53      $U	 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�68   $
 border��54      .\�55        $ 	0:0:0.066��63   $	 -10Q�56        57      $ 	0:0:0.134��63   $ 10Q�58        59      $ 0:0:0.2��63   $ 0Q�5:      5;      5<      5=      5>      .+�5A   
   �� -   5         ��Name$ BackgroundOverlayBorder��5A      ���	#FF06C409 J� Opacity$ 0Q�5C      �� 5E   
   -   5        $ border��5E      $	��280��5F      $	��130��5G      
������� �� CornerRadius$ 5��5I      $��Center=�5J      $��Center=�5K       �� Padding$ 20q�5L       J� RenderTransformOrigin$ 0.5,0.5&�5M      z�5N      V� 5O      .~�5P      �� �� 5Q      �� 5R      T� 5S      5T       J� Effect 5V      3  -System.Windows.Media.Effects.DropShadowEffect  5W         Color$ 	#FF252525��6#      Opacity$	 0.7Q�5X      ._�5Z      �� .+�5[      �  � ColumnDefinitions 5\      �� 5]      $
��auto �6+   �� 5^      $��* �6+    � RowDefinitions 5`      �� 5a      $
��auto �6(   �� 5b      $
��auto �6(   �� 5c      $
��auto �6(   .+�5f      �� $��0��6   $��0��6)   $��5q�69   '	  !Ufo.Commander.Resources.Resources 	  UsernameText#��Z 6D   �� 5g      $��1��6   $��0��6)   $��5q�69    	  PasswordText#��Z 6D   �� 5i      -   5        $��txtUsername��5i   F   $��0��6   $��1��6+   $��5q�6;   ��6Y   �� *
Username+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . G� 5j      -   5        $��txtPassword��5j   J   $��1��6"   $��1��6/   $��5q�6?    G� PasswordChar$ *��6]   � 5k      $��2��6   $��1��6(    5l      �� 5m      $��* �6/   �� 5n      $��* �6/   .+�5q      �� -   5        $��btnExit��5q   ?   $��0��6!   $
��4, 5q�61    	  ExitText#��Z 6N    �� IsCancel . 6�   �� 5s      -	   5        $��btnLogin��5s   ?   $��1��6!   $
��4, 5q�61     	  	LoginText#��Z  6O   ! �� 	IsDefault! . {�6�   �� *	IsValid+5t      5u      � 5v       5w      �� 5x      $��* �6+   �� 5y      $
��Auto �6+   .+�5|      � -
   5        " �Name$" ErrorsSummaryContainer��5|      $��0��5}   	   $y�	Collapsed=�5~   	   $��	0,10,10,0q�5   	    5�      �� 5�      $
��Auto �6,   �� 5�      $
��Auto �6,   .+�5�      �� $�� ��6$   
���  ��$
��Bold"�5�      �� 5�      $��1��6$   
���  ��$��0,5,0,0q�5�      ��5�      �� *ValidationErrorsString+5�      5�      � 5�      -   5        $" ValidSummaryContainer��5�      $��0��5�   	   $y�	Collapsed=�5�   	   $��Center=�5�   	   $
��Left=�5�   	   $��0,10,5,0q�5�   	   5�      5�      5�      5�      5�      5�      