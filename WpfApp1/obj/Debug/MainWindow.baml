   M S B A M L   `   `   `  ����T  PBourne Again Stat Checker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:MainAppMainApp  5   	       MainApp.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:MainApp     5   	     � Title$  Stat Checker��5   	   $	��520��6   $
��1045��6+    � 
ResizeMode$ NoResize=�68    � UseLayoutRounding .  �� BitmapScalingMode$ NearestNeighbor=�5
   	    J� SnapsToDevicePixels .  � WindowStyle$
 None=�5   	    � AllowsTransparency .  �� ClearTypeHint$ Enabled=�5   	    � 	Resources 5      3  -System.Windows.Media.Effects.DropShadowEffect   glow	   
BlurRadius
   Color   ShadowDepth �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius �� Triggers P� Property P� Value   Opacity N� EnterActions g� Duration �� TargetProperty	 �� To g� 	BeginTime  bg  	tile_host  
tile_white  tile_red  	tile_covs  tile_marauder  TearsButton �� ImageSource j� Stretch j� 
AlignmentY j� 
AlignmentX  FingersButton 	 EmberButton 
 RedSignButton  WhiteSignButton  RedEyeButton  	BSCButton  TreeCumButton  DS��%�  &	        'd� ?     '��     &	 o    &	 �    &	 �    &	 J    &	 �    &	 �    &	 .	    &	 �	    &		 B
    &	
 �
    &	 S    &	 �    &	 g    &	 �    &	 w      5   
   $	 10Q�6(   $
 White��68   $ 0Q�6F   6X   �� 5   
   " d�6   .�5      ��  �@�OverridesDefaultStyle . 66   �� 5       � ��$ 75��6&   �� 5       � ��$ 25��6'   �� 5       � �� �#2828286=   �� 5       � �� 5      �� 5      " d�6&   .R�5      �� $��border��62   $ 4��6!   $��1q�5      #��z��5      ._�5      �� $��Center=�6/   $��Center=�6L   5      5      5        5!      P� 5"       �@d�	IsChecked$
 TrueY�6/   . �5#      ��  �@J�Effect 5$        5%      $	 10Q�6/   $
 White��6?   $ 0Q�6M   $ 1Q�6]   6k   5'      �� 5(       � �� �#fff6B   �� 5)       � �� �#0006B   5*      P� 5+       �@d�	IsChecked$ FalseY�6/   . �5,      ��  �@J�Effect 5-        5.      $	 10Q�6/   $
 White��6?   $ 0Q�6M   $ 0Q�6]   6k   50      �� 51       � �� �#2828286E   �� 52       � �� �#D5D5C76E   53      55      �� 56   
   " ��6   .�57      ��  �@�OverridesDefaultStyle . 66   �� 58       � ��
 �   �6;   �� 59       � �� 5:      �� 5;      " ��6&   .R�5<      �� $��border��62   $ 4��6!   $��1q�5=      #��z��5>      ._�5?      �� $��Center=�6/   $��Center=�6L   5@      5A      5C       5D      P� 5E       �@J�IsMouseOver . . �5G      ��  �@J�Effect 5H        5I      $	 10Q�6/   $
 White��6?   $ 0Q�6M   6_   5K      5L      P� 5M       � �� .  5N      �� 5O      .��5P      �� .��5Q   "   �� $ 0:0:0.1D�61   $1 +(Button.Background).(SolidColorBrush.Color)�6D   $ #555555X�6�   �� 5R   "   $ 0:0:0.1D�61   $ 0:0:0.1X�6D   $1 +(Button.Background).(SolidColorBrush.Color)�6X   $ BlackX�6�   5S      5T      5V      5X      ��5Y   
   0,pack://application:,,,/Resources/pics/bg.png��6O   ��5Z   
   73pack://application:,,,/Resources/pics/tile-host.png��6]   ��5[   
   84pack://application:,,,/Resources/pics/tile_white.png��6_   ��5\   
   62pack://application:,,,/Resources/pics/tile_red.png��6[   ��5]   
   73pack://application:,,,/Resources/pics/tile_covs.png��6]   ��5^   
   ;7pack://application:,,,/Resources/pics/tile_marauder.png��6e   �� 5_   
   $E ?pack://application:,,,/Resources/pics/buttons/tearsofdenial.png��6)   $
 Fill=�6w   $ Center=�6�   $ Center=�6�   �� 5`   
   $? 9pack://application:,,,/Resources/pics/buttons/fingers.png��6+   $
 Fill=�6s   $ Center=�6�   $ Center=�6�   �� 5a   
   $= 7pack://application:,,,/Resources/pics/buttons/ember.png��6)   $
 Fill=�6o   $ Center=�6~   $ Center=�6�   �� 5b   
   $D >pack://application:,,,/Resources/pics/buttons/redsoapstone.png��6+   $
 Fill=�6x   $ Center=�6�   $ Center=�6�   �� 5c   
   $F @pack://application:,,,/Resources/pics/buttons/whitesoapstone.png��6-   $
 Fill=�6|   $ Center=�6�   $ Center=�6�   �� 5d   
   $> 8pack://application:,,,/Resources/pics/buttons/redeye.png��6*   $
 Fill=�6q   $ Center=�6�   $ Center=�6�   �� 5e   
   $D >pack://application:,,,/Resources/pics/buttons/blackcrystal.png��6'   $
 Fill=�6t   $ Center=�6�   $ Center=�6�   �� 5f   
   $< 6pack://application:,,,/Resources/pics/buttons/seed.png��6+   $
 Fill=�6p   $ Center=�6   $ Center=�6�   �� 5g   
   .�5h      ��  � ��$7 1pack://application:,,,/Resources/#OptimusPrinceps)�67   �� 5i       � �� �#D5D5C767   5j      5l      ��5m      �� 5n   
   $
 Fill=�6   # [ 6$   $	 Top=�6F   $ Center=�6W    �� Opacity$ 1Q�6k    �� 	Transform 5o      �� 5p        �� ScaleX$  1Q�6!   ! �� ScaleY$! 1Q�6,   5r      .��5u      � -   5        $��MainBackground��5u      " � Orientation$" Vertical=�6'   #���  6>   $��
0, 0, 0, 0q�6[   .+�5v   
   �� $	��Top=�6   $��0q�6-   $
��1045��68   .+�5w      �� -   5        # ��Name$# ExitBtn��5w      $��Right=�6&   $��20��6B   $��20��6M   $��
0, 6, 8, 0q�6o   .��5x      �� $��x��6   $��14(�6%   5y      5z      � 5{   
   -   5        $��MainWind��5{      $" 
Horizontal=�6$   #���  6=   $��
0, 0, 0, 0q�6Z   .+�5|   
   �� $	��Top=�6   $��40, 25, 10, 0q�6-   $	��365��6D   .+�5}      �� $
��name��6   $��25(�6$   �� 5~      $��soul lvl��6   $��20(�6(   �� 5      $��vigor��6   $��20(�6%   �� 5�      $��
attunement��6   $��20(�6*   �� 5�      $��stamina��6   $��20(�6'   �� 5�      $��vitality��6   $��20(�6(   �� 5�      $��strength��6   $��20(�6(   �� 5�      $��	dexterity��6   $��20(�6)   �� 5�      $��intelligence��6   $��20(�6,   �� 5�      $��faith��6   $��20(�6%   �� 5�      $
��luck��6   $��20(�6$   �� 5�      $��is stats match��6   $��20(�6.   �� 5�      -   5        $# AttachButton��5�   B   $��25��6   $	��115��6!   $��
5, 2, 5, 0q�6.   $ J� RenderTransformOrigin$$ 0.5,0.5&�6s   z�5�      V� 5�      .~�5�      �� �� 5�      �� 5�      T� 5�      % T� Y$% 30Q�6-   5�      .��5�      �� $��18(�6   $��reattach��6*   5�      5�      �� 5�      -   5        $��Player1��5�   S   $	��Top=�6   $��5, 20, 5, 0q�61   $	��380��6F   ��5�      �� 5�      -   5        
imageTile1��$
 Fill=�5�   1   # �  6@   $	 Top=�6j   $ Center=�6{   $ 1Q�6�    5�      �� 5�      $  1Q�6)   $! 1Q�64   5�      .+�5�      (� & (� Stretch$& Uniform=�6   $	��125��6(   $��30��64   ' (� StretchDirection$' DownOnly=�6@   .��5�      �� -   5        $��p1Name��5�   1   $��0, 10, 0, 0q�6   $��20(�6?   $��Empty��6M   5�      �� 5�      -   5        $��	p1SoulLvL��5�      $��
0, 5, 0, 0q�6*   $��20(�6>   $	��125��6L   $��25��6X   ( �� TextAlignment$( Center=�6d   �� 5�      -	   5        $��p1Stats��5�      $��20(�6'   $	��125��65   $	��205��6A   $( Center=�6N   �� 5�      -
   5        $��p1Statscheck��5�      $��20(�6,   $	��125��6:   $��25��6F   $( Center=�6R   �� 5�      -   5        $��Center=�5�      $��5q�6L   
) � Tag$) 1��6W   .��5�      �� -   5        $��KillPlayer1��5�   6   $
��KILL��6   $��20(�6(   66   5�      �� 5�      -   5        $��Center=�5�      $��0q�6L   $) 1��6W   .��5�      �� -   5        $��KickPlayer1��5�   6   $
��KICK��6   $��20(�6(   66   5�      5�      �� 5�      -   5        $��Player2��5�   S   $	��Top=�6   $��5, 20, 5, 0q�61   $	��380��6F   ��5�      �� 5�      -   5        
imageTile2��$
 Fill=�5�   1   # �  6@   $	 Top=�6k   $ Center=�6|   $ 1Q�6�    5�      �� 5�      $  1Q�6)   $! 1Q�64   5�      .+�5�      (� $& Uniform=�6   $	��125��6(   $��30��64   $' DownOnly=�6@   .��5�      �� -   5        $��p2Name��5�   1   $��0, 10, 0, 0q�6   $��25(�6?   $��Empty��6M   5�      �� 5�      -   5        $��	p2SoulLvL��5�      $��
0, 5, 0, 0q�6)   $��20(�6=   $	��125��6K   $��25��6W   $( Center=�6c   �� 5�      -   5        $��p2Stats��5�      $��20(�6'   $	��125��65   $	��205��6A   $( Center=�6N   �� 5�      -   5        $��p2Statscheck��5�      $��20(�6,   $	��125��6:   $��25��6F   $( Center=�6R   �� 5�      -   5        $��Center=�5�      $��5q�6L   $) 2��6W   .��5�      �� -   5        $��KillPlayer2��5�   6   $
��KILL��6   $��20(�6(   66   5�      �� 5�      -   5        $��Center=�5�      $��0q�6L   $) 2��6X   .��5�      �� -   5        $��KickPlayer2��5�   6   $
��KICK��6   $��20(�6(   66   5�      5�      �� 5�      -   5        $��Player3��5�   S   $	��Top=�6   $��5, 20, 5, 0q�61   $	��380��6F   ��5�      �� 5�      -   5        
imageTile3��$
 Fill=�5�   1   # �  6@   $	 Top=�6i   $ Center=�6z   $ 1Q�6�    5�      �� 5�      $  1Q�6)   $! 1Q�64   5�      .+�5�      (� $& Uniform=�6   $	��125��6(   $��30��64   $' DownOnly=�6@   .��5�      �� -   5        $��p3Name��5�   1   $��0, 10, 0, 0q�6   $��25(�6?   $��Empty��6M   5�      �� 5�      -   5        $��	p3SoulLvL��5�      $��
0, 5, 0, 0q�6)   $��20(�6=   $	��125��6K   $��25��6W   $( Center=�6c   �� 5�      -   5        $��p3Stats��5�      $��20(�6'   $	��125��65   $	��205��6A   $( Center=�6N   �� 5�      -   5        $��p3Statscheck��5�      $��20(�6,   $	��125��6:   $��25��6F   $( Center=�6R   �� 5�      -   5        $��Center=�5�      $��5q�6L   $) 3��6X   .��5�      �� -    5        $��KillPlayer3��5�   6   $
��KILL��6   $��20(�6(   66   5�      �� 5�      -!   5        $��Center=�5�      $��0q�6L   $) 3��6X   .��5�      �� -"   5        $��KickPlayer3��5�   6   $
��KICK��6   $��20(�6(   66   5�      5�      �� 5�      -#   5        $��Player4��5�   S   $	��Top=�6   $��5, 20, 5, 0q�61   $	��380��6F   ��5�      �� 5�      -$   5        
imageTile4��$
 Fill=�5�   1   # �  6@   $	 Top=�6n   $ Center=�6   $ 1Q�6�    5�      �� 5�      $  1Q�6)   $! 1Q�64   5�      .+�5�      (� $& Uniform=�6   $	��125��6(   $��30��64   $' DownOnly=�6@   .��5�      �� -%   5        $��p4Name��5�   1   $��0, 10, 0, 0q�6   $��25(�6?   $��Empty��6M   5�      �� 5�      -&   5        $��	p4SoulLvL��5�      $��
0, 5, 0, 0q�6)   $��20(�6=   $	��125��6K   $��25��6W   $( Center=�6c   �� 5�      -'   5        $��p4Stats��5�      $��20(�6'   $	��125��65   $	��205��6A   $( Center=�6N   �� 5�      -(   5        $��p4Statscheck��5�      $��20(�6,   $	��125��6:   $��25��6F   $( Center=�6R   �� 5�      -)   5        $��Center=�5�      $��5q�6L   $) 4��6W   .��5�      �� -*   5        $��KillPlayer4��5�   6   $
��KILL��6   $��20(�6(   66   5�      �� 5�      -+   5        $��Center=�5�      $��0q�6L   $) 4��6X   .��5�      �� -,   5        $��KickPlayer4��5�   6   $
��KICK��6   $��20(�6(   66   5�      5�      �� 5�      --   5        * ��Name$* Player5��5�   T   $	��Top=�6   $��5, 20, 5, 0q�61   $	��380��6G   ��5�      �� 5�      -.   5        
imageTile5��$
 Fill=�5�   1   # �  6@   $	 Top=�6j   $ Center=�6{   $ 1Q�6�    5�      �� 5�      $  1Q�6)   $! 1Q�64   5�      .+�5�      (� $& Uniform=�6   $	��125��6(   $��30��64   $' DownOnly=�6@   .��5�      �� -/   5        + ��Name$+ p5Name��5�   1   $��0, 10, 0, 0q�6   $��25(�6A   $��Empty��6O   5�      �� 5�      -0   5        $+ 	p5SoulLvL��5�      $��
0, 5, 0, 0q�6,   $��20(�6@   $	��125��6N   $��25��6Z   $( Center=�6f   �� 5�      -1   5        $+ p5Stats��5�      $��20(�6)   $	��125��67   $	��205��6C   $( Center=�6P   �� 5�      -2   5        $+ p5Statscheck��5�      $��20(�6.   $	��125��6<   $��25��6H   $( Center=�6T   �� 5�      -3   5        $��Center=�5�      $��5q�6L   $) 5��6W   .��5�      �� -4   5        $+ KillPlayer5��5�   6   $
��KILL��6   $��20(�6(   66   5�      �� 5�      -5   5        $��Center=�5�      $��0,0,0,15q�6L   $) 5��6^   .��5�      �� -6   5        $+ KickPlayer5��5�   6   $
��KICK��6   $��20(�6(   66   5�      5�      �� 5      $	��Top=�6   $��5, 30, 5, -80q�61   $	��450��6H   .+�5     � $
��0, 5q�6   .+�5     �� -7   5        $	��155��5     $��25��6%   $��0,10,0,0q�61   .��5     �� $��kill all mobs��6    $��16(�65   5     5     � 5     $
��0, 5q�6   .+�5      � -8   5        ,  �Name$, bonfireListBox��5     -  � NavigationUIVisibility$- Hidden=�5     5	     � 5
     $
��0, 5q�6   .+�5     �� -9   5        $	��155��5     $��25��6%   $��0,0,0,0q�61   .��5     �� -:   5        $+ homeward_btn��5      $��homeward to bonfire��66   $��14(�6Q   5     5     � 5     $��0,0,0,5q�6   5     � 5     $��0,0,0,5q�6   .+�5     �� -;   5        $��75��5     $��25��6$   $��0,5,0,0q�60   .��5     �� $��heal me��6    $��15(�6/   5     �� 5     -<   5        $��75��5     $��25��6$   $��8,5,0,0q�60   .��5     �� $��kill me��6    $��15(�6/   $$ 0,0.5&�6=   5     5     � 5     $��0,0,0,10q�6   .+�5     �� -=   5        $��75��5     $��25��6$   .��5     �� $��parry me��6    $��15(�60   $$ 0,0.5&�6>   5     �� 5     ->   5        $��75��5     $��25��6$   $��8,0,0,0q�60   .��5     �� $��heal all��6    $��15(�60   $$ 0,0.5&�6>   5      5!     � 5"     $��0,0,0,10q�6   .+�5#     �� -?   5        $��75��5#     $��25��6$   $y�	Collapsed=�6K   .��5$     �� $
��RTSR��6    $��15(�6,   $$ 0,0.5&�6:   5%     5&     � 5'     $
��0, 5q�6   .+�5(     d� -@   5        $��AutoreviveCheckBox��5(  0   $��0,0,8,0q�6   . d� 	IsChecked$. FalseY�6�   .��5)     �� $��auto-revive��6    $��13(�63   5*     d� 5+     -A   5        $. FalseY�5+  Y   .��5,     �� $��
anti-parry��6    $��13(�62   5-     5.     � 5/     $
��0, 5q�6   .+�50     d� -B   5        $��CovsTrigger��50  0   $��0,0,8,0q�6   .��51     �� $��	covenants��6    $��14(�61   52     d� 53     -C   5        / d�Name$/ Ember��53     $. FalseY�6b   .��54     �� $��ember��6    $��14(�6-   55     56     � 57     .+�58     �� -D   5        $��75��58     $��25��6$   $��0,0,0,0q�60   .��59     �� $
��mark��6    $��15(�6,   5:     �� 5;     -E   5        $��75��5;     $��25��6$   $��8,0,0,0q�60   .��5<     �� $��recall��6    $��15(�6.   $$ 0,0.5&�6<   5=     5>     � 5?     $��0, 10q�6   $y�	Collapsed=�6'   .+�5@     �� ID:6!   �� 5A     -F   5        $��CurrentAnimText1��5A     $	��140��62   
���   ����#D5D5C76h   5B     � 5C     $��0, 90, 0, 0q�6   .+�5E     d� -G   5        $��48��5E     $��
2, 0, 5, 0q�6*   $
. TrueY�6~   .��5F     �� $
��MapV��6    5G     d� 5H     -H   5        $��48��5H     $��
0, 0, 5, 0q�6*   .��5I     �� $��HighC��6    5J     d� 5K     -I   5        $��48��5K     $��
0, 0, 5, 0q�6*   .��5L     �� $
��LowC��6    5M     5O     5P     �� 5Q  
   0 �� Orientation$0 
Horizontal=�6   $��Center=�6/   $	��Top=�6L   $��184, 15, 0, 0q�6d   $��60��6{   $	��660��6�   .+�5R     � $
��24,0q�6   6(   �� 5S     -J   5        $
��5, 0q�5S     $��Stretch=�6}   $��60��6�   $��60��6�   #��[ 6�   6�   �� 5T     -K   5        $
��5, 0q�5T     $��Center=�6}   $��60��6�   $��60��6�   #��[ 6�   6�   �� 5U     -L   5        $
��5, 0q�5U     $��Center=�6}   $��60��6�   $��60��6�   #��[	 6�   6�   �� 5V     -M   5        $
��5, 0q�5V     $��Center=�6}   $��60��6�   $��60��6�   #��[ 6�   6�   �� 5W     -N   5        $
��5, 0q�5W     $��Center=�6}   $��60��6�   $��60��6�   #��[
 6�   6�   �� 5X     -O   5        $
��5, 0q�5X     $��Center=�6}   $��60��6�   $��60��6�   #��[ 6�   6�   �� 5Y     -P   5        $
��5, 0q�5Y     $��Center=�6}   $��60��6�   $��60��6�   #��[ 6�   6�   �� 5Z     -Q   5        $
��5, 0q�5Z     $��Center=�6}   $��60��6�   $��60��6�   #��[ 6�   6�   5[     5\     5]     5^     