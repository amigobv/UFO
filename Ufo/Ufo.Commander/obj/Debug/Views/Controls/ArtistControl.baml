   M S B A M L   `   `   `  ����H  DUfo.Commander, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Ufo.Commander.ResourcesUfo.Commander.Resources  5      9!clr-namespace:Ufo.Commander.ViewsUfo.Commander.Views  5	      K*clr-namespace:Ufo.Commander.Views.ControlsUfo.Commander.Views.Controls  5
      0    *Ufo.Commander.Views.Controls.ArtistControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6resx%clr-namespace:Ufo.Commander.Resources     5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5      h dMicrosoft.Expression.Interactions, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bei9http://schemas.microsoft.com/expression/2010/interactions  5      -local!clr-namespace:Ufo.Commander.Views  5	      5ctrl*clr-namespace:Ufo.Commander.Views.Controls  5
      .��5      � $
��1200��6   $	��850��6   $��30, 100q�6+     � ColumnDefinitions  5   
   �� 5      $��1* �6   �� 5      $��1* �6   .+�5   
   �� $��1��6    �� Orientation$ Vertical=�6&   $��0, 120q�6=   .  (System.Windows.Interactivity.Interaction   	Behaviors 5      ?  9Microsoft.Expression.Interactivity.Core.DataStateBehavior  5         Value$
 True��5         	TrueState$ 
ValidState��5         
FalseState$ InvalidState��5         Binding 5   '   �� *	IsValid+5      '  !System.Windows.VisualStateManager   VisualStateGroups 5      %  System.Windows.VisualStateGroup  5      -   5        ValidationSummaryStates��   States. 5         System.Windows.VisualState  -   5        
ValidState��	   
Storyboard.	 5      �� .��5      T� 
 �� TargetProperty$
 (UIElement.Visibility)�6<    �� 
TargetName$ ValidSummaryContainer��5      ..�5    "   i�  R� KeyTime$ 0��69    R� Value 5!   &     System.Windows.Visibility 5"   *   Visible=�6>   5$   #   5%      U� 5&      $
 (UIElement.Opacity)�6<   $ BackgroundOverlayBorder��5'      .\�5(   "   9  3System.Windows.Media.Animation.EasingDoubleKeyFrame   O� KeyTime$ 0:0:1��67    O� Value$	 0.5Q�5)        5*   "   $ 0:0:2��67   $ 0Q�5+      5,      5-      5.        5/      -   5        InvalidState��.	 50      �� .��51      T� $
 (UIElement.Visibility)�6<   $ ErrorsSummaryContainer��52      ..�53   "   i� $ 0��69    54   &    55   *   Visible=�6>   57   #   58      U� 59      $U
 O(UIElement.RenderTransform).(TransformGroup.Children)[3].(TranslateTransform.X)�6<   $ border��5:      .\�5;   "     $ 	0:0:0.066��67   $	 -10Q�5<        5=   "   $ 	0:0:0.134��67   $ 10Q�5>        5?   "   $ 0:0:0.2��67   $ 0Q�5@      5A      5B      5C      5D      .+�5G      �� -   5         ��Name$ BackgroundOverlayBorder��5G      ���	#FF06C409 J� Opacity$ 0Q�5I      �� 5K      -   5        $ border��5K      $	��500��5L      $	��430��5M      
������� �� CornerRadius$ 5��5O      $��Center=�5P      $��Center=�5Q       �� Padding$ 20q�5R       J� RenderTransformOrigin$ 0.5,0.5&�5S      z�5T      V� 5U      .~�5V      �� �� 5W      �� 5X      T� 5Y      5Z       J� Effect 5\      3  -System.Windows.Media.Effects.DropShadowEffect  5]         Color$ 	#FF252525��6'      Opacity$	 0.7Q�5^      ._�5`      �� $��5q�6   '	   !Ufo.Commander.Resources.Resources 	  ArtistEditText#��Z 6*   .��5a      �  � RowDefinitions 5b      �� 5c      $
��Auto �6,   �� 5d      $
��Auto �6,   .+�5g      � $��1��6     5h      �� 5i   "   $��* �63   �� 5j   "   $
��Auto �63   .+�5m      � -   5         �Name$ ErrorsSummaryContainer��5m   #   $��0��5n      $y�	Collapsed=�5o      $��	0,10,10,0q�5p       5r   "   �� 5s   &   $
��Auto �64   �� 5t   &   $
��Auto �64   .+�5w   "   �� $�� ��6,   
���  ��$
��Bold"�5y      �� 5z   "   $��1��6,   
���  ��$��0,5,0,0q�5}      ��5{      �� *ValidationErrorsString+5}      5      � 5�      -   5        $ ValidSummaryContainer��5�   #   $��0��5�      $y�	Collapsed=�5�      $��Center=�5�      $
��Left=�5�      $��0,10,5,0q�5�      5�      5�      � 5�      $��0��6     5�      �� 5�   "   $��1* �63   �� 5�   "   $��2* �63    5�      �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   �� 5�   "   $
��auto �60   .+�5�      �� -   5        $��lblName��5�   $   $��0��5�   $   $��0��61   $��5q�5�   $    	  NameText#��Z 5�   $   �� 5�      -	   5        $��txtName��5�   &   $��0��5�   &   $��1��63   $��5q�5�   &   $��14(�5�   &   ��5�   &   �� *Name+ �� Mode$ TwoWay=� �� ValidatesOnDataErrors . 5�   &   �� 5�      -
   5        $��
lblCountry��5�   (   $��1��5�   $   $��0��61   $��5q�5�   (    	  CountryText#��Z 5�   (   �� 5�      -   5        $��
txtCountry��5�   &   $��1��5�   &   $��1��63   $��5q�5�   &   $��14(�5�   &   ��5�   &   �� *	Country+$ TwoWay=� . 5�   &   �� 5�      -   5        $��lblEmail��5�   (   $��2��5�   $   $��0��61   $��5q�5�   (    	  	EmailText#��Z 5�   (   �� 5�      -   5        $��txtEmail��5�   &   $��2��5�   &   $��1��63   $��5q�5�   &   $��14(�5�   &   ��5�   &   �� *Email+$ TwoWay=� . 5�   &   �� 5�      -   5        $��lblHomepage��5�   $   $��3��5�   $   $��0��61   $��5q�5�   $     	  HomepageText#��Z  5�   $   �� 5�      -   5        $��txtHomepage��5�   &   $��3��5�   &   $��1��63   $��5q�5�   &   $��14(�5�   &   ��5�   &   �� *
Homepage+5�   &   �� 5�      -   5        $��lblDecription��5�   (   $��4��5�   $   $��0��61   $��5q�5�   (   ! 	  DescriptionText#��Z! 5�   (   �� 5�      -   5        $��txtDescription��5�   &   $��4��5�   &   $��1��63   " �� MinLines$" 5��5�   &   # �� MaxLines$# 5��63   $ �� TextWrapping$
$ Wrap=�5�   &   "% �� VerticalScrollBarVisibility$
% Auto=�5�   &   & �� AcceptsReturn& . $��5q�5�   &   $��14(�5�   &   ��5�   &   �� *Description+5�   &   �� 5�      -   5        $��lblCategory��5�   (   $��5��5�   $   $��0��61   $��5q�5�   (   ' 	  CategoryText#��Z' 5�   (   �� 5�      -   5        $��
cbCategory��5�   /   $��5��5�   '   $��1��64   $��5q�5�   /   ( �� DisplayMemberPath$
( Name��5�   /   ) �� SelectedIndex$) 0��5�   /   * �� SelectedValuePath$
* Name��5�   /   $+ �� IsSynchronizedWithCurrentItem$+ FalseY�5�   /   ��5�   /   �� *
Categories+, �� SelectedItem, 5�   /   �� *
Category+$ TwoWay=� . - �� SelectedValue- 5�   /   �� . �� Path$. Category.Name�5�      �� 5�      $��6��6)   $��1��66   $ 
Horizontal=�6F   .+�5�   "   �� -   5        $��btnBrowsePicture��5�   )   $��10, 5, 5, 5q�5�   )   / 	  BrowsePictureText#��Z/ 5�   )   5�   )   �� 5�   "   -   5        $��btnBrowseVideo��5�   )   $��5q�5�   )   0 	  BrowseVideoText#��Z0 5�   )   5�   )   5�      5�      5�      5�      5�      1 =� ErrorTemplate1 5�      �� 5�      .R�5�      � .+�5�      �� $��customAdorner��64   $��Center=�5�      5�      �� 5�      2 ��Name$2 	textBlock��6$   $��Right=�5�   
   $��10,0,5,0q�5   
   $	��150��5  
   $
��Wrap=�5  
   $��WordEllipsis=�5  
   
���  ����5�   
   �� 3 �� ElementName$3 customAdorner��$8. 2AdornedElement.(Validation.Errors)[0].ErrorContent�5  
   5     5     5     �� 5
  
   $��0��6   $ Vertical=�6%   .+�5     �� -   5        $" BackgroundOverlayBorderMedia��5     ���	#FF06C409$ 0Q�5     �� 5     -   5        $ borderMedia��5     $	��600��5     $	��625��5     
�������$ 5��5     $��Center=�5     $��Center=�5     $ 20q�5     $ 0.5,0.5&�5     z�5     V� 5     .~�5     �� �� 5     �� 5     T� 5     5      5        5!     $ 	#FF252525��6'   $	 0.7Q�5"     ._�5$     �� $��5q�6   4 	  
ArtistText#��Z4 6&   .��5%     �  5&     �� 5'     $��1* �6,   �� 5(     $��1* �6,   .+�5+     � $��0��6     5,     �� 5-  "   $��* �63   �� 5.  "   $��* �63   .+�50     �� $��0��6)   $ Vertical=�69   .+�51  "   �� $ 
Horizontal=�6-   .+�52  &   �� $��Name:��60   $��2q�6=   $��60��6H   �� 53  &   $��2q�6F   ��60   �� *Name+6F   54  #   �� 56  "   $ 
Horizontal=�6-   .+�57  &   �� $��Country:��60   $��2q�6@   $��60��6L   �� 58  &   $��2q�6I   ��60   �� *	Country+6I   59  #   �� 5;  "   $ 
Horizontal=�6-   .+�5<  &   �� $��	Category:��60   $��2q�6A   $��60��6M   �� 5=  &   $��2q�6N   ��60   �� *CategoryName+6N   5>  #   �� 5?  "   $ 
Horizontal=�6-   .+�5@  &   �� $��	Homepage:��60   $��2q�6A   $��60��6M   �� 5A  &   $��2q�6J   ��60   �� *
Homepage+6J   5B  #   �� 5D  "   $ 
Horizontal=�6-   .+�5E  &   �� $��Email:��60   $��2q�6>   $��60��6J   �� 5F  &   $��2q�6G   ��60   �� *Email+6G   5G  #   �� 5J  "   $
��Wrap=�6-   $��2q�5K  F   ��6)   �� *Description+6F   5L     �� 5M     $��1��6$   $��0��64   $	��150��6\   $	��100��6h   $��3q�6u   ��6A   �� *	Picture+6u   5N     .
   (Ufo.Commander.Views.Controls.VideoViewer
  5O     $��1��6+   $��5q�6V   5 � DataContext5 68   �� *Video+6V   5P     5Q     5R     5S     5T     5U     