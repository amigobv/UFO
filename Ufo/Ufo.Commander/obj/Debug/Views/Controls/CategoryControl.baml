   M S B A M L   `   `   `  ����H  DUfo.Commander, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Ufo.Commander.ResourcesUfo.Commander.Resources  5      K*clr-namespace:Ufo.Commander.Views.ControlsUfo.Commander.Views.Controls  5	      R NUfo.Commander.ViewModel, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullnLclr-namespace:Ufo.Commander.ViewModel.Basic;assembly=Ufo.Commander.ViewModelUfo.Commander.ViewModel.Basic 5
      2    ,Ufo.Commander.Views.Controls.CategoryControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5      0resx%clr-namespace:Ufo.Commander.Resources  5      6local*clr-namespace:Ufo.Commander.Views.Controls  5	      UvmLclr-namespace:Ufo.Commander.ViewModel.Basic;assembly=Ufo.Commander.ViewModel  5
      .��5      ��   �� Orientation$  Vertical=�6   $��30, 200q�6(   .  (System.Windows.Interactivity.Interaction   	Behaviors 5   
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
   -   5        $ border��5E      $	��350��5F      $	��150��5G      
������� �� CornerRadius$ 5��5I      $��Center=�5J      $��Center=�5K       �� Padding$ 20q�5L       J� RenderTransformOrigin$ 0.5,0.5&�5M      z�5N      V� 5O      .~�5P      �� �� 5Q      �� 5R      T� 5S      5T       J� Effect 5V      3  -System.Windows.Media.Effects.DropShadowEffect  5W         Color$ 	#FF252525��6#      Opacity$	 0.7Q�5X      ._�5Z      �� $��5q�6   '	   !Ufo.Commander.Resources.Resources 	  CategoryText#��Z 6"   .��5[      �  � RowDefinitions 5\      �� 5]      $��* �6(   �� 5^      $
��Auto �6(   .+�5a      � $��0��6    � ColumnDefinitions 5b      �� 5c      $��2* �6/   �� 5d      $��3* �6/    5f      �� 5g      $
��Auto �6,   �� 5h      $
��Auto �6,   .+�5k      �� -   5        $��lblShortName��5l       $��0��5k       $��0��6-   $��4q�5m        	  IdentifierText#��Z 5n       �� 5p      -   5        $��txtIdentifier��5q   !   $��0��5p   "   $��1��6/   $��5q�5r   !   $��14(�5t   !   ��5s   !   �� *
Identifier+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . 5t   !   �� 5v      -   5        $��lblName��5w       $��1��5v       $��0��6-   $��4q�5x       #��Z 5y       �� 5{      -	   5        $��txtName��5|   !   $��1��5{   "   $��1��6/   $��5q�5}   !   $��14(�5   !   ��5~   !   �� *Name+$ TwoWay=� . 5   !   5�      � 5�      $��1��6    5�      �� 5�      $��* �6/   �� 5�      $
��Auto �6/   .+�5�      � -
   5         �Name$ ErrorsSummaryContainer��5�      $��0��5�   	   $y�	Collapsed=�5�   	   $��	0,10,10,0q�5�   	    5�      �� 5�   "   $
��Auto �60   �� 5�   "   $
��Auto �60   .+�5�      �� $�� ��6(   
���  ��$
��Bold"�5�      �� 5�      $��1��6(   
���  ��$��0,5,0,0q�5�      ��5�      �� *ValidationErrorsString+5�      5�      � 5�      -   5        $ ValidSummaryContainer��5�      $��0��5�   	   $y�	Collapsed=�5�   	   $��Center=�5�   	   $
��Left=�5�   	   $��0,10,5,0q�5�   	   5�      5�      5�      5�      5�       =� ErrorTemplate 5�   
   �� 5�      .R�5�      � .+�5�      �� $��customAdorner��60   $��Center=�5�      5�      �� 5�       ��Name$ 	textBlock��6    $��Right=�5�   
   $��10,0,5,0q�5�   
   $	��150��5�   
   $
��Wrap=�5�   
   $��WordEllipsis=�5�   
   
���  ����5�   
   ��   �� ElementName$  customAdorner��! �� Path$8! 2AdornedElement.(Validation.Errors)[0].ErrorContent�5�   
   5�      5�      5�      5�      