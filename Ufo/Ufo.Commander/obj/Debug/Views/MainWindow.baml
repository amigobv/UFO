   M S B A M L   `   `   `  ����H  DUfo.Commander, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullK*clr-namespace:Ufo.Commander.Views.ControlsUfo.Commander.Views.Controls  5   	   A%clr-namespace:Ufo.Commander.ResourcesUfo.Commander.Resources  5   	   -clr-namespace:Ufo.CommanderUfo.Commander  5   	   $    Ufo.Commander.Views.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ;ctrl*clr-namespace:Ufo.Commander.Views.Controls     5   	   6resx%clr-namespace:Ufo.Commander.Resources     5   	   -localclr-namespace:Ufo.Commander     5   	     � Title$  	Commander��5
   	   $
��Auto��6   $
��Auto��6(    � WindowState$ 	Maximized=�5   	   .��5      � .+�5   
   �� -   5         �� TabStripPlacement$	 Top=�5      $��10q�5      
������� � 	Resources 5       �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 ��Name
 �� Triggers P� Property P� Value �� 
TargetName��%J  '��       �� 5      " ��6   .�5      ��  � �� 5      �� 5      " ��6.   .R�5   "   �� $��Border��6)   $��1,1,1,0q�67   
�������$ 4,4,0,0��6i   $	��2,0q�6�   ._�5   &   �� $	 ContentSite��67   $��Center=�5   )   $��Center=�5   )   $��Header��5   )   $
��10,2q�5   )   5   #   
 5   "   P� 5   &    �@��
IsSelected . . �5    *   �� $ Border��61    � ��
 ��·�6[   5!   '   P� 5"   &    �@��
IsSelected .  . �5#   *   �� $ Border��61    � ��
 �����6[   5$   '   5&      5(      5)      5*      .@�5+      �� '   !Ufo.Commander.Resources.Resources   ScheduleText#��Z 6   .��5,      2   ,Ufo.Commander.Views.Controls.ScheduleControl   � DataContext 6'   �� *
Schedule+5-      �� 5.         ArtistsText#��Z 6   .��5/      1   +Ufo.Commander.Views.Controls.ArtistsControl   6&   �� *	Artists+50      �� 51         
VenuesText#��Z 6   .��52      0   *Ufo.Commander.Views.Controls.VenuesControl   6%   �� *Venues+53      �� 54         CategoriesText#��Z 6   .��55      4   .Ufo.Commander.Views.Controls.CategoriesControl   6)   �� *
Categories+56      �� 57         LocationsText#��Z 6   $��3,0,-3,0q�6G   .��58      3   -Ufo.Commander.Views.Controls.LocationsControl   6(   �� *	Locations+59      5:      5<      5=      