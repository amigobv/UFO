   M S B A M L   `   `   `  ����  Ufo.Commander.    (Ufo.Commander.Views.Controls.VideoViewer   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5        J� CommandBindings  5	      )  #System.Windows.Input.CommandBinding  5
   
   -   5           Command$ MediaCommands.Play��5
      6S     5   
   -   5        $ MediaCommands.Pause��5      6U     5   
   -   5        $ MediaCommands.Stop��5      6S    � 	Resources 5      ��%    5      .��5      � -   5         �Name$ GrMain��5       5   
   ��%    5       � RowDefinitions 5   
   �� 5      $��9* �6   $	��250��6(   �� 5      $��40 �6   $��40��6(    � ColumnDefinitions 5   
   �� 5      $��* �6   .+�5   
   r� -   5        $��Player��5      $��0��5       r� LoadedBehavior$ Pause=�5        r� ScrubbingEnabled .  r� Source 5      �� 5#      � 5%   
   $��1��6   $��35��6    5&      �� 5'      $��40 �6#   $��30��6.   �� 5(      $��40 �6#   $��30��6.   �� 5)      $��40 �6#   $��40��6.   �� 5*      $��62 �6#   $��62��6.   �� 5+      $��3* �6#   $��80��6.   �� 5,      $��80 �6#   $��80��6.   .+�5/      �� -   5        	 ��Name$	 BtnPlay��5/   %   $��0��6   $��0q�66   $��8q�6J   $��MediaCommands.Play��6U   
����  �$��0q�6�   .��50      �� $��5q�6   $8��2pack://application:,,,/assets/images/MediaPlay.png��6#   51      �� 53      -   5        $	 BtnPause��53   %   $��1��6   $��0q�67   $��8q�6K   $��MediaCommands.Pause��6V   
����  �$��0q�6�   .��54      �� $��5q�6   $9��3pack://application:,,,/assets/images/MediaPause.png��6#   55      �� 57      -   5        $	 BtnStop��57   %   $��2��6   $��0q�66   $��8q�6J   $��MediaCommands.Stop��6U   
����  �$��0q�6�   .��58      �� $��5q�6   $8��2pack://application:,,,/assets/images/MediaStop.png��6#   59      �� 5;      $��3��6   
 �� Orientation$
 Vertical=�6)   $��Center=�6@   $��2q�6[   .+�5<      �� -	   5        $��LblProgressStatus��5<      $
��5, 0q�61   .��6@   
00:00:006J   �� 5=      -
   5        $��LblProgressEnd��5=      $
��5, 0q�6.   .��6=   
00:00:006G   5>      � 5@      -   5        $��SliProgress��5@   *   $��4��6   $��35��5A   )    � Maximum$ 1Q�65   $��Stretch=�5B   )   $��Center=�5C   )    J� IsManipulationEnabled .  � Value$ 0Q�5J   )   5K      �� 5M      -   5         ��Name$ 	SliVolume��5M   %   $��5��6   $��Center=�5N   $   $��0q�5O   $   $��2, 2, 10, 2q�68   $��25��6M   $��70��6Y    � Minimum$ 0Q�5P   $   $	 100Q�60    �� IsMoveToPointEnabled .  $��Stretch=�5R   $   5T      5U      5V      5W      