   M S B A M L   `   `   `  ����G  CSprotify_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Sprotify_WPFSprotify_WPF  5   	       Sprotify_WPF.Artiest   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Sprotify_WPF     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5            MaterialDesignDarkForeground#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	      MaterialDesignDarkBackground#���  5   	     MaterialDesignFont#���  6L    � Title$ Artiest��5   	   $	��600��6   $	��600��6&   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ btnHome��5      $��0��6Z   $��0��6j   $��5q�6w   ��6"   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Home=�   Size$ 25X�6�   �� 5   
   -   5        $ 
btnRefresh��5       � ToolTip$ Refresh lijst��6^   $��2��6v   $��1��6�   $��5q�6�   ��6%     $ Refresh=�$ 25X�6�   �� 5!   
   $��	Artiesten��6   $��0��6%   #���   62   $��1��6n   $��5q�6~   $��23(�6�   $
��Bold"�6�   �� 5"   
   -   5        $ Artiest toevoegen��5"   I   $��0��6e   $��2��6r   $��5q�6�   ��6     $
 Plus=�$ 25X�6�   �� 5$   
   $��2��6   $��2��6"   .+�5%      �� -   5        $ btnChangeData��5%      $��5q�6c   $ Data aanpassen��6n   $��1��6�   $��2��6�   ��6,     $	 Cog=�$ 25X�6�   �� 5&      -   5        $ btnUpdateData��5&      $��5q�6d   $ Data updaten��6o   $��2��6�   $��2��6�   ��6,     $
 Edit=�$ 25X�6�   �� 5'      -   5        $ btnDeleteData��5'      $��5q�6f   $ Data verwijderen��6q   $��3��6�   $��2��6�   ��6,     $ Delete=�$ 25X�6�   5(      &   System.Windows.Controls.DataGrid  5*   
   -   5        	  Name$	 dataArtiesten��5*      $��5q�6*   
   AutoGenerateColumns
 .     
IsReadOnly . $��0��6c   $��1��6s   $��2��6�   $��2��6�      Columns 5+      0  *System.Windows.Controls.DataGridTextColumn  5,      ,  &System.Windows.Controls.DataGridColumn   Header$
 Naam��6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *naam+6>     5-      $ Maandelijkse Luisteraars��6Q    6%   �� *maandelijkseLuisteraars+6Q     5.      $ Verified��6B    6%   �� *
verified+6B   50      �� 53   
    �� Orientation$ 
Horizontal=�6   $��4��6.   $��0��6;   $��2��6K   $��5q�6_   .+�54      �� -	   5         ��Name$ txtNaam��54      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$  Naam               ��6'   $��5q�6]   �� 55      -
   5        $ txtMaand��55      $%  Maandelijkse luisteraars      ��6(   $��5q�6i   �� 56      -   5         ��Name$ 
cbVerified��56      $��Verified��6+   $��5q�6>    d� IsThreeState .  6I   57      58      59      