   M S B A M L   `   `   `  ����T  PBourne Again Stat Checker, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:MainApp.CrutchesMainApp.Crutches  5          MainApp.Crutches.Bonfires   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0localclr-namespace:MainApp.Crutches     5        N� Title$  Bonfires��5       � 	Resources 5
         WindowBackgroundBrush �� Color  ComboBoxToggleButton �� 
TargetType ��Name �� CornerRadius F�Name � ColumnDefinitions  ComboBoxTextBox �� 
TargetType	 �� Property
 �� Value �� 	ClickMode d� 	IsChecked �� Path �� Mode �� RelativeSource J� IsHitTestVisible ��Name �� 
IsReadOnly �� 
IsReadOnly �� IsDropDownOpen � AllowsTransparency J� SnapsToDevicePixels � ActualWidth �� MaxDropDownHeight K� IsItemsHost-  'System.Windows.Input.KeyboardNavigation   DirectionalNavigation �� Triggers P� Property P� Value3  -System.Windows.Media.Effects.DropShadowEffect   
BlurRadius   Color    ShadowDepth��%&  &	        &	      7   &	 �    '�� ;    7  7  7   �� 5   
   $ Black��68   �� 5   
   " d�67   .R�5      � .+�5      �� $ Border��6   $��2��6*   $ 5��6>   
���   ����#000111$��1q�6x   �� 5      $��0��6   $ 5,0,0,5��6)   $��1q�6A   8��  
���   �$��0,0,1,0q�6�   F� 5      $ Arrow��6   $��1��6&   ���#D5D5C7$��Center=�6F   $��Center=�6c   "����        � 	=  	= � z     	6~    5      �� 5      �� 5      $��20 �6'   5      5      �� 5   
   " ��62   .R�5      �� $ PART_ContentHost��6   |�.  #��z��6A   5      �� 5   
   " ��6*   .�5      �� 	 � ��
 5      �� 5      " ��6&   .R�5       � .+�5"      d� $��ToggleButton��5$   
   8��  $��2��5&   
   |�.  $ Press=�5)   
    5(   
   �� $ IsDropDownOpen�$ TwoWay=� �� *TemplatedParent+5,      �� 5-      $��ContentSite��5.   	    .  $��3,3,23,3q�50   	   $��Center=�51   	   $
��Left=�52   	   �� 53      $ PART_EditableTextBox��6&   8�� $
��Left=�56   
   $��Center=�57   
   $��3,3,23,3q�58   
   |�.  
������ ���#D5D5C7$y�Visible=�5<   
   # z 5=   
   ��54   
   Z� 5=   
   � 5>      $��Popup��5?   	   $��Bottom=�5@   	   #��z 5A   	    . |�.  $��Slide=�5D   	   .��5E   "   � $��DropDown��5F       . #��z 5H      #��z 5I      .+�5J   &   �� $ DropDownBorder��5K      8�� $��1q�5M      �� 5N   &   $��4,6,4,6q�63    . .��5O   *   ��  . $ 	Contained=�6H   5P   '   5Q   #   5R      5S      5T      5V       5W      P� 5X       �@J�IsMouseOver . . �5Z      �� 	 �@J�Effect
 5[        5\      $ 10Q�6/   $ White��6?   $  0Q�6M   6_   5_      5`      5c      5d      .��5f      � .+�5g   
   �� $��1��6   $��0q�5h      
���   �$ 5��5j      ! J� Opacity$! 1Q�5k      ._�5n      �� " �� Orientation$" Vertical=�6   $��Center=�5o   !   $��Center=�5p   !   .+�5r      �� $	��155��6   $��25��5s   !   $��0,0,0,0q�5t   !   ._�5x      �� -   5        $��cmbBonfireList��5x      # � OverridesDefaultStyle# . $	��155��5z   %   $��25��5{   %   $��14(�5|   %   $��#OptimusPrinceps)�5}   %   $��Center=�5~   %   $	��Top=�5   %   $��0q�5�   %   $��Center=�5�   %   $��5,0,0,0q�5�   %   
���   ����#D5D5C7$ �� 
IsEditable$ . $��0q�5�   %   60   5�      5�      5�      5�      5�      