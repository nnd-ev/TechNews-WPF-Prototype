   M S B A M L   `   `   `  ����I  EObicanKorisnik, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:ObicanKorisnikObicanKorisnik  5   	       ObicanKorisnik.Postovi   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   .localclr-namespace:ObicanKorisnik     5   	     � Title$  Postovi��5   	   $��329.773��6   $��593.466��6*    � 	Resources 5	         SearchedStudent �� Orientation
 � Tag 
 Nadjen��%6  &	        &	 �     �� 5
   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� $��5q�6   .+�5      ��  6"   �� *PostID+��69   �� *Naslov+5      5      5      �� 5   
   .R�5      �� $ 
Horizontal=�6   .+�5      �� ��6   �� *Naslov+5      5      5      .��5      � .+�5   
   �� $
��Left=�6   $
��Wrap=�6/   $��
Trazi Post��6C   $	��Top=�6U   $��	26,20,0,0q�6m   $��17��6�   $��57��6�   �� 5   
   -   5        $��tbSearch��5      $
��Left=�6"   $��30��6=    �� TextWrapping$
 Wrap=�6I   $	��Top=�6]   $	��337��6u   $��
114,14,0,0q�6�    K� ZIndex$	 999��6�   �� 5   
   -   5        $��lbPrikaziSearchData��5      $y�	Collapsed=�6-   #��[  6D   $
��Left=�6u   $��99��6�   $	��Top=�6�   $	��332��6�   $��
114,48,0,0q�6�   $
 9999��6  &   System.Windows.Controls.DataGrid  5!   
   -   5        $��
glavniGrid��5!      $��Center=�6%   $	��188��6B   $	��Top=�6O      AutoGenerateColumns .  $	��561��6�   $��16,98,10.2,0q�6�   $   HorizontalScrollBarVisibility$ Hidden=�6�      CanUserAddRows .  	   Columns	 5"      0  *System.Windows.Controls.DataGridTextColumn  5#      ,  &System.Windows.Controls.DataGridColumn
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 300 6@      Header$ Naslov��6L   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Naslov+6L     5$      $	
 160 6I   $ 
Kategorija��6U    6%   �� *NazivKategorije+6U   4  .System.Windows.Controls.DataGridTemplateColumn  5&      $ Otvori��6)   $	
 100 69      CellTemplate 5'      �� 5(      .R�5)      �� $��	btnOtvori��6%   -   5        $��Otvori��5)   6   $��Center=�6I   $	��100��6g   6s   5*      5,      50      �� 51   
   -   5        $��	btnProfil��51      $��Profil��6"   $
��Left=�63   $	��Top=�6N   $��50��6f   $��	528,4,0,0q�6q   $��23��6�   6�   54      55      