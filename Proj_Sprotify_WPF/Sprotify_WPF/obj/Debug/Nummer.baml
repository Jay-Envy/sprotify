   M S B A M L   `   `   `  ����G  CSprotify_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Sprotify_WPFSprotify_WPF  5   	       Sprotify_WPF.Nummer   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:Sprotify_WPF     5   	   b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5            MaterialDesignDarkForeground#���   5	   	   $��Regular"�5
   	   $��13(�5   	   &   System.Windows.Media.TextOptions    TextFormattingMode$  Ideal=�5   	      TextRenderingMode$
 Auto=�5   	      MaterialDesignDarkBackground#���  5   	     MaterialDesignFont#���  5   	    � Title$ Nummer��5   	   $	��600��6   $
��1200��6%   .��5      �  � ColumnDefinitions 5   
   �� 5      $
��auto �6   �� 5      $��* �6   �� 5      $
��auto �6    � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6   .+�5   
   �� -   5         ��Name$ btnHome��5      $��0��6Z   $��0��6j   $��5q�6w   ��6"   0  *MaterialDesignThemes.Wpf.PackIconExtension     Kind$
 Home=�   Size$ 25X�6�   �� 5   
   $��Nummers��6   $��0��6#   #���   60   $��1��6l   $��5q�6|   $��23(�6�   $
��Bold"�6�   �� 5    
   -   5        $ btnAddNummer��5       $��5q�6_    � ToolTip$ Nieuw nummer��6j   $��0��6�   $��2��6�   ��6'     $
 Plus=�$ 25X�6�   �� 5!   
   $��3��6   $��2��6"   .+�5"      �� -   5        $ btnChangeData��5"      $��5q�6c   $ Data aanpassen��6n   $��1��6�   $��2��6�   ��6,     $	 Cog=�$ 25X�6�   �� 5#      -   5        $ btnUpdateData��5#      $��5q�6d   $ Data updaten��6o   $��2��6�   $��2��6�   ��6,     $
 Edit=�$ 25X�6�   �� 5$      -   5        $ btnDeleteData��5$      $��5q�6f   $ Data verwijderen��6q   $��3��6�   $��2��6�   ��6,     $ Delete=�$ 25X�6�   5%      �� 5(   
   -   5        	 ��Name$	 	txtSearch��5(      $��1��6%   $��0��62   $��2��6B   $��5q�6V   )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 Zoek nummer��6a   6�   �� 5)   
   -   5        $
 Zoek��5)   K   $��5q�6Z   $��1��6e   $��2��6r   ��6     $ Search=�$ 25X�6�   &   System.Windows.Controls.DataGrid  5,   
   -	   5          Name$ 
dataSearch��5,      $��5q�6'      AutoGenerateColumns .     
IsReadOnly . $��0��6`   $��3��6p   $��2��6}      Columns 5-      0  *System.Windows.Controls.DataGridTextColumn  5.      ,  &System.Windows.Controls.DataGridColumn   Header$ Titel��6F   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Nummer.titel+6F     5/      $ Artiest��6F    6%   �� *Artiest.naam+6F     50      $ Lengte��6G    6%   �� *Nummer.lengte+6G     52      $ Genre��6F    6%   �� *Nummer.genre+6F     53      $ Regio��6F    6%   �� *Nummer.regio+6F     54      $ Platenmaatschappij��6S    6%   �� *Nummer.platenMaatschappij+6S     55      $ Aantal keer gespeeld��6S    6%   �� *Nummer.aantalKeerGespeeld+6S   57      �� 5:   
    �� Orientation$ 
Horizontal=�6   $��4��6.   $��0��6;   $��2��6K   $��5q�6_   .+�5;      �� -
   5        $	 txtTitel��5;      $
  Titel               ��6(   $��5q�6_   �� 5<      -   5         ��Name$ 
cmbArtiest��5<      $��2��6+    �� DisplayMemberPath$
 naam��6`   $��2��6y   $��5q�6�   $��2��6�   $
 Artiest         ��6�   ��6;   ��  �� Path$ Artiest�6�   �� 5=      -   5        $	 	txtLengte��5=      $
  Lengte      ��6)   $��5q�6X   �� 5>      -   5        $	 txtGenre��5>      $
  Genre        ��6(   $��5q�6X   �� 5?      -   5        $	 txtRegio��5?      $
  Regio        ��6(   $��5q�6X   �� 5@      -   5        $	 	txtPlaten��5@      $
  Platenmaatschappij  ��6)   $��5q�6`   5B      5D      5E      