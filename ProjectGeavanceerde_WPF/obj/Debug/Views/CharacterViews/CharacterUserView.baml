   M S B A M L   `   `   `  ����R  NProjectGeavanceerde_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:ProjectGeavanceerde_WPF.ViewsProjectGeavanceerde_WPF.Views  5   	   5    /ProjectGeavanceerde_WPF.Views.CharacterUserView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:ProjectGeavanceerde_WPF.Views     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   -   5          �Name$  CharacterWindow��5	   	    � Title$ CharacterUserView��5
      $��526.5��6"   $
��1319��61   .��5      �  � ShowGridLines .  
����� � � RowDefinitions 5   
   �� 5      $
��auto �6   $��40��6*   �� 5      $	��21* �6   �� 5      $	��21* �6   �� 5      $	��21* �6   �� 5      $	��21* �6   �� 5      $	��21* �6   �� 5      $	��21* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid     AutoGenerateColumns .  $��1��60   $��0��6=   ���#B2EFE8   
IsReadOnly . $��5��5       $��6��5!      $��	5,5,10,10q�5"      ��5      �� *
Characters+ �� ValidatesOnDataErrors .  �� SelectedItem 5      �� *SelectedCharacter+ . 	   Columns	 5#      0  *System.Windows.Controls.DataGridTextColumn  5$      ,  &System.Windows.Controls.DataGridColumn
   Header$

 Naam��6>   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *Name+6N     5%      $
 Bounty��6W    6%   �� *Bounty+ �� StringFormat$ {0:N0}��6i     5&      $
 Soort��6G    6%   �� *Species.Name+6X     5'      $
 Bloed��6I    6%   �� *Bloodtype.Name+6Z     5(      $
 Birthday��6T    6%   �� *
Birthday+$ m��6h     5)      $

 Haki��6?    6%   �� *Haki+6O     5*      $
 
Devilfruit��6I    6%   �� *DevilFruitText+6_     5+      $
 Gender��6@    6%   �� *Gender+6R   5-      �� 50   
   $��
Characters��6   ���#00b4d8
�������$��0��6P   $��0��6]   
���   �$��2q�6�   $
��Auto��6	  $��Center=�6  ��6�   �� *CloseWindowCommandChar+ �� Mode$ OneWay=���6�   ��  �� ElementName$ CharacterWindow��6  �� 51   
   $��Affiliations��6   ���#023e8a
�������$��0��6Q   $��1��6^   
���   �$��2q�6�   $
��Auto��6  $��Center=�6  ��6�   �� *CloseWindowCommandAff+$ OneWay=���6�   �� $ CharacterWindow��6  �� 52   
   $
��Arcs��6   $��0��6!   ���#023e8a
�������$��2��6V   
���   �$��2q�6z   $
��Auto��6   $��Center=�6  ��6�   �� *CloseWindowCommandArc+$ OneWay=���6�   �� $ CharacterWindow��6  �� 53   
   $��Places��6   $��0��6#   ���#023e8a
�������$��3��6X   
���   �$��2q�6|   $
��Auto��6  $��Center=�6  ��6�   �� *CloseWindowCommandPlace+$ OneWay=���6�   �� $ CharacterWindow��6  �� 54   
   $��World Timeline��6   ���#023e8a
�������$��0��6T   $��4��6a   
���   �$��2q�6�   $
��Auto��6	  $��Center=�6  ��6�   �� *CloseWindowCommandWT+$ OneWay=���6�   �� $ CharacterWindow��6  56      57      