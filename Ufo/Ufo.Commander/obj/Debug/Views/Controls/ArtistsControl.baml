   M S B A M L   `   `   `  ����H  DUfo.Commander, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:Ufo.Commander.ResourcesUfo.Commander.Resources  5   	   K*clr-namespace:Ufo.Commander.Views.ControlsUfo.Commander.Views.Controls  5   	   9!clr-namespace:Ufo.Commander.ViewsUfo.Commander.Views  5   	   1    +Ufo.Commander.Views.Controls.ArtistsControl   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6resx%clr-namespace:Ufo.Commander.Resources     5   	   ;ctrl*clr-namespace:Ufo.Commander.Views.Controls     5   	   3local!clr-namespace:Ufo.Commander.Views     5   	   .��5
      �   � ColumnDefinitions  5   
   �� 5      $	��200 �6   �� 5      $��3* �6   .+�5   
   � $��0��6    � RowDefinitions 5      �� 5      $
��Auto �6    �� 5      $��3* �6    .+�5      �� -   5        $��btnNewArtist��5   "   $��0��6   $��10, 5, 10, 5q�5      $	��150��5      '   !Ufo.Commander.Resources.Resources   NewArtistText#��Z 5      5      �� 5      -   5        $��listArtists��5      $��1��5      $��0q�6$    �� DisplayMemberPath$
 Name��5!      $
��Auto=�5"      ��5      �� *	Artists+ �� SelectedItem 5       �� *CurrentArtist+5"      5$      �� 5&   
   $��1��6   $��5��5'      $
��left=�5(      $��Stretch=�62   � 5*   
   $��1��6    5+      �� 5,      $��5* �6    �� 5-      $
��auto �6    .+�50      0   *Ufo.Commander.Views.Controls.ArtistControl  $��0��6!    � DataContext 6.   �� *CurrentArtist+�� 52      $��1��6    �� Orientation$ 
Horizontal=�6&   $��RightToLeft=�6?   .+�53      �� -   5        $��btnSave��54      $��70��53      $��
5, 5, 5, 5q�55         SaveText#��Z 56      {�57      �� *CurrentArtist.IsValid+58      �� 59      -   5        $��	btnRemove��5:      $��70��59      $��
5, 5, 5, 5q�5;         
RemoveText#��Z 5<      ��5=      �� *CurrentArtist.RemoveCommand+5>      5?      5@      5A      