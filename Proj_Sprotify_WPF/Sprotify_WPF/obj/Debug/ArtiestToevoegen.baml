   M S B A M L   `   `   `  ����G  CSprotify_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Sprotify_WPFSprotify_WPF  5   	   #    Sprotify_WPF.ArtiestToevoegen   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Sprotify_WPF     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5            MaterialDesignDarkForeground#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	      MaterialDesignDarkBackground#���  5   	     MaterialDesignFont#���  5   	    � Title$ ArtiestToevoegen��5   	   $	��150��6"   $	��400��6/   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5    
   �� $O��Ihttps://www.materialui.co/materialIcons/av/playlist_add_white_192x192.png��6   $��35��6c   $��0��6n   $��0��6~   �� 5!   
   $��1��6   $��0��6"   $��2��62   $��5q�6C   .+�5"      	� -   5         	�Name$ 	rbArtiest��5"       	� 	GroupName$
 Item��6-   $��Artiest��6>    d� 	IsChecked$ FalseY�6P   $��5q�6b   $��0��6m   $��1��6}   6�   	� 5#      -   5        $ rbNummer��5#      $
 Item��6,   $��Nummer��6=   $ FalseY�6N   $��5q�6`   $��0��6k   $��1��6{   6�   5%      �� 5'   
   -   5         ��Name$ txtNaam��5'      )  #MaterialDesignThemes.Wpf.HintAssist	   Hint$
	 Naam��6#   $��0��6J   $��1��6W   $��5q�6g   �� 5(   
   -   5        
 ��Name$
 
cbCheckbox��5(      $��Verified��6'   $��0��6:   $��2��6G   $��5q�6W   �� 5+   
   -   5        $ txtRegio��5+      $	 Regio��6$   $��5q�6K   $��2��6V   $��1��6f   �� 5,   
   -   5        $ txtGenre��5,      $	 Genre��6$   $��5q�6K   $��1��6V   $��1��6f   �� 5-   
   -   5        $ 	txtLengte��5-      $	 Lengte��6%   $��5q�6M   $��3��6X   $��1��6h   $��2��6u   �� 5.   
   -	   5        $ 	txtPlaten��5.      $	 Platenmaatschappij��6%   $��5q�6Y   $��1��6d   $��2��6t   �� 5/   
   -
   5         ��Name$ 
cmbArtiest��5/      $��2��6'    �� DisplayMemberPath$
 naam��6\   $��2��6u   $��5q�6�   $��2��6�   $	 Artiest��6�   ��67   ��  �� Path$ Artiest�6�   �� 50   
   -   5         � ToolTip$
 Icon��50   I   $��5q�6X   $��0��6c   $��3��6p   $��2��6�   ��6   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Plus=�   Size$ 25X�6�   52      53      