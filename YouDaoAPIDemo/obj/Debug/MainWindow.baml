   M S B A M L   `   `   `  ����H  DYouDaoAPIDemo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:YouDaoAPIDemoYouDaoAPIDemo  5   	       YouDaoAPIDemo.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   -localclr-namespace:YouDaoAPIDemo     5   	     � WindowStartupLocation$  CenterScreen=�5       � Title$ 有道云Demo��5   	   $	��400��6   $	��600��6&    � Icon$ bitbug_favicon.ico��62   ���#D0D1D6 � ShowInTaskbar .  � 
ResizeMode$ NoResize=�5	   4    � AllowsTransparency .  � WindowStyle$
 None=�5
   #   
������  � 	Resources 5         Color.Text.Normal  Window.Minimize  Window.Close  Button.Tempate �� 
TargetType	 �Name
 ��Name F�Name �� Path �� RelativeSource �� Triggers P� Property P� Value �� 
TargetName �� Value �� Property  Style.Button.Base �� 
TargetType��%�  &	        &	      &	 G     &	 >    &	 �    7  ��5   
   #666666��6=   ��5   
   M0,6 V8 H10 V6 Z�6C   ��5   
   ��M3,8L3,9 2,9 2,10 0,10 0,8 1,8 1,7 2,7 2,6 3,6 3,4 2,4 2,3 1,3 1,2 0,2 0,0 2,0 2,1 3,1 3,2 4,2 4,3 6,3 6,2 7,2 7,1 8,1 8,0 10,0 10,2 9,2 9,3 8,3 8,4 7,4 7,6 8,6 8,7 9,7 9,8 10,8 10,10 8,10 8,9 7,9 7,8 6,8 6,7 4,7 4,8 3,8z�6  �� 5   
   " ��61   .R�5      � $	 RootGrid��6   
������ .+�5      �� $
 CoverBorder��6   #��z��6.   #��z��6N   F� 5      $ IconPath��6   ���#808080#��z��68   $��Center=�6[   $��Center=�6v   ��5      �� $$ (local:ControlHelper.Geometry)� �� *TemplatedParent+5       5      P� 5       �@J�IsMouseOver . . �5      �� $ CoverBorder��6    5      �� $+ %(local:ControlHelper.BackgroundHover)� �� *TemplatedParent+ � ���� 5      $ IconPath��6    5      �� $+ %(local:ControlHelper.ForegroundHover)� �� *TemplatedParent+ � ��5      P� 5       � �� . . �5      �� $ CoverBorder��6    5      �� $- '(local:ControlHelper.BackgroundPressed)� �� *TemplatedParent+ � ���� 5       $ IconPath��6    5!      �� $- '(local:ControlHelper.ForegroundPressed)� �� *TemplatedParent+ � ��5"      P� 5#       � {� .  . �5$      �� $ IconPath��6    �@J�Opacity$	 0.4Q�6F   5%      5'      �� 5)   
   " ��6*   .�5*      ��  �@�FocusVisualStyle 61   Z� �� 5+       � ��$ 36��6&   �� 5,       � ��$ 30��6'   �� 5-       � ��$	 5 2q�6(   �� 5.       � ��8   6)   5/      51      .��52      �� 
�������$��1q�6%   ._�53   
   � 
�������}�. '  !System.Windows.Shell.WindowChrome   IsHitTestVisibleInChrome .  � RowDefinitions 54      �� 55      $
��Auto �6    �� 56      $��* �6    .+�58      � -   5        ���	#FFF0F0F0.+�59      ��  �� Orientation$ 
Horizontal=�6   .+�5:      �� -   5         ��Name$ 	IconImage��5:      $
��Fill=�6/    J� SnapsToDevicePixels .  � UseLayoutRounding . $��16��6r   $��16��6}   $��Center=�5;      $��8 0 0 0q�63   $��bitbug_favicon.ico��6D   �� 5<      -   5         ��Name$ TitleTextBlock��5<       $	��5 0q�68   $��有道云Demo��6E   #��[  5=      $
��Left=�5>      $��Center=�67    .  5@      5A      �� 5C      $ 
Horizontal=�6   $��Right=�66   .+�5E      �� -   5        $��MinimizeButton��5E      $��6 0 0 0q�63   #��[ 6D   !   YouDaoAPIDemo.ControlHelper   Geometry# [ 5G         BackgroundHover �	#0D000000   BackgroundPressed �	#14000000   ForegroundHover �#808080    ForegroundPressed  �#8080805K      �� 5N      -   5        $��CloseButton��5N      #��[ 60   # [ 5P       �#D94C4C �#B34747 �#FFFFFF  �	#99FFFFFF5T      5V      5W      � 5Y      $��1��6    5Z      �� 5[      $
��Auto �6$   �� 5\      $
��Auto �6$   �� 5]      $��* �6$   �� 5^      $��* �6$   .+�5`      �� -   5        ! ��Name$! SearchingTextBox��5`      $	��120��64   $��0 10 0 0q�6_   $	��4,2q�6q   ��6@   �� *SearchingText+6�   �� 5a      $��1��6   $��搜索��6&   $��26��6U   $��Center=�6a   $��0 10 0 0q�6~   $	��120��6�   ��63   �� *SearchCommand+6�   � 5b      $��2��6   $��0 10 0 0q�6$   " � ColumnDefinitions" 5c      �� 5d      $
��Auto �6+   �� 5e      6-   .+�5g      �� $��单词信息：��6    6/   �� 5h      $��1��6    $
��Wrap=�6Z   $��Stretch=�5i       ��5h   0   �� *Explaniation+# �� Mode$# TwoWay=�5i       5j      � 5k      $��3��6   $��0 10 0 0q�6$   " 5l      �� 5m      $
��Auto �6+   �� 5n      $��* �6+   67   .+�5p      �� $��详细信息：��6    6/   �� 5q      $��1��6   $ �� TextWrapping$
$ Wrap=�6^   $��Stretch=�5r       $
��Auto=�6>   ��5q   .   �� *SearchResultDetail+$# TwoWay=�5r   >   5s      5t      5u      5v      5w      