   M S B A M L   `   `   `  ����E  AWpfAppExam, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullA%clr-namespace:WpfAppExam.ClientVisualWpfAppExam.ClientVisual  5   	   .    (WpfAppExam.ClientVisual.ClientMainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   7local%clr-namespace:WpfAppExam.ClientVisual     5   	     � Title$  ClientMainWindow��5   	   $	��450��6"   $	��800��6/    � WindowStartupLocation$ CenterScreen=�5	   	    � 
ResizeMode$ NoResize=�5
   	    � 	Resources 5       	  Icons �� 
TargetType �� Property �� Value �� 
TargetType �� CornerRadius	 �� Triggers
 :� RoutedEvent �� TargetProperty g� Duration	 t� To�� 5      %  &	        �� 5      " ��6"   .�5      ��  �@�OverridesDefaultStyle . 6:   �� 5       � ��
 ���� 6/   �� 5       � �� 5      �� 5      " ��6*   .R�5      �� $��Border��67   $ 20��6%   #��z��6E   ._�5   "   �� $��Center=�63   $��Center=�6P   5      	 5      :� 5   "   $
 
MouseEnter��6/   .[�5   &   �� .��5   *   �� .��5   .   t� $ Margin�6A   $ 	0:0:0.100D�6d   $ 2,2,2,2X�6y   5   +   5   '   5   #   :� 5    "   $
 
MouseLeave��6/   .[�5!   &   �� .��5"   *   �� .��5#   .   t� $ Margin�6A   $ 	0:0:0.100D�6d   $ 1,1,1,1X�6y   5$   +   5%   '   5&   #   :� 5'   "   $
 PreviewMouseDown��6/   .[�5(   &   �� .��5)   *   �� .��5*   .   t� $ Margin�6A   $ 	0:0:0.100D�6d   $ 4,4,4,4X�6y   5+   +   5,   '   5-   #   :� 5.   "   $
 PreviewMouseUp��6/   .[�5/   &   �� .��50   *   �� .��51   .   t� $ Margin�6A   $ 	0:0:0.100D�6d   $ 0,0,0,0X�6y   52   +   53   '   54   #   56      58      59      5:      .��5=      �  � ColumnDefinitions 5>   
   �� 5?      $��50 �6   �� 5@      .+�5C   
   clr-namespace:AA  6@    � 6
    behaclr-namespace:A     6@   -   5          �Name$ 	MainFrame��5C   ]   $��1��6     � NavigationUIVisibility$ Hidden=�6    6]   �� 5E   
   -   5         ��Name$ ButtonPanel��5E      $��0��6*    �� Orientation$ Vertical=�6:   .+�5F      �� $��28��6   $��35��6!   $��Center=�6,   
�������$��1q�6a   $ 14��6u   $��Center=�6�   $��0,20,0,0q�6�   ._�5G      �� -   5         � Cursor$
 Hand��5G      #��[  6'   .��5H      �� $ 
Horizontal=�6!   .+�5I      �� ��5J      �� 5K   "   " ��6(   .�5L   &   ��  � ��$ Resources/user-ico.png��6?    �� Triggers 5N   &   �� 5O   *    �� Binding 66   ��  �� Path$ IsMouseOver� �� ElementName$
 Cart�� �� Value True6m   .a�5P   .   ��  � ��$ Resources/user-ico.png��6G   5Q   +   �� 5R   *    66   ��  �� RelativeSource �� *FindAncestor+ �� AncestorType" �� �� AncestorLevel$ 1��$ 	IsPressed� True6�   .a�5S   .   ��  � ��$ Resources/user-ico.png��6G   5T   +   5V   #   5X      5Y      5Z      5[      �� 5]      $��28��6   $��35��6!   $��Center=�6,   $��Center=�6K   $��0,20,0,0q�6f   ._�5^      �� -   5        $
 Hand��5^      #��[  6'   .��5_      �� $ 
Horizontal=�6!   .+�5`      �� ��5a      �� 5b   "   " ��6(   .�5c   &   ��  � ��$ Resources/search-ico.png��6?    5d   &   �� 5e   *    66   �� $ IsMouseOver�$
 Cart�� True6m   .a�5f   .   ��  � ��$ Resources/search-ico.png��6G   5g   +   �� 5h   *    66   ��  �� *FindAncestor+" ��$ 1��$ 	IsPressed� True6�   .a�5i   .   ��  � ��$ Resources/search-ico.png��6G   5j   +   5l   #   5n      5o      5p      5q      �� 5t      $��28��6   $��35��6!   $��Center=�6,   $��Center=�6K   $��	0,270,0,0q�6f   ._�5u      �� -   5        $
 Hand��5u      #��[  6'   .��5v      �� $ 
Horizontal=�6!   .+�5w      �� ��5x      �� 5y   "   " ��6(   .�5z   &   ��  � ��$ Resources/quit.png��6?    5{   &   �� 5|   *    66   �� $ IsMouseOver�$
 Cart�� True6m   .a�5}   .   ��  � ��$ Resources/quit.png��6G   5~   +   �� 5   *    66   ��  �� *FindAncestor+" ��$ 1��$ 	IsPressed� True6�   .a�5�   .   ��  � ��$ Resources/quit.png��6G   5�   +   5�   #   5�      5�      5�      5�      5�      5�      5�      