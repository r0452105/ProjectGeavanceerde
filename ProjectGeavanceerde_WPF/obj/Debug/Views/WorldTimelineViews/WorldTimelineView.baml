   M S B A M L   `   `   `  ����R  NProjectGeavanceerde_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullM+clr-namespace:ProjectGeavanceerde_WPF.ViewsProjectGeavanceerde_WPF.Views  5   	   5    /ProjectGeavanceerde_WPF.Views.WorldTimelineView   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   =local+clr-namespace:ProjectGeavanceerde_WPF.Views     5   	   -   5          �Name$  WTWindow��5   	    � Title$ WorldTimelineView��5	   	   $��526.5��6#   $
��1319��62   .��5
      �  � ShowGridLines .  
����� � � RowDefinitions 5   
   �� 5      $
��auto �6   $��40��6*   �� 5      $	��21* �6   �� 5      $	��21* �6   �� 5      $	��21* �6   �� 5      $	��21* �6   �� 5      $	��21* �6   �� 5      $	��21* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      �� 5      �� 5      .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ datagridEvents��5         AutoGenerateColumns .  $��1��6G   $��0��6T   ���#B2EFE8   
IsReadOnly . $��4��5      $��5��6'   $��5q�68   ��5      �� *Events+ �� ValidatesOnDataErrors . 	 �� SelectedItem	 5      �� *SelectedEvent+ . 
   Columns
 5       0  *System.Windows.Controls.DataGridTextColumn  5!      ,  &System.Windows.Controls.DataGridColumn   Header$ EventID��6A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	EventID+   
Visibility 6R   �� *
visibility+6v     5"      $ Omschrijving��6F    6%   �� *Omschrijving+6^     5#      $
 Date��6B    6%   �� *
EditDate+6R   5%      �� 5'   
   $��Nieuw Event Aanmaken��6   ���#00b4d8$��1��6F   $��4��6S   
���   �$��3q�6w   $��5q�6�   $
��Auto��6  ��6�   �� *CloseWindowCommandWTAdd+ �� Mode$ OneWay=���6�   ��  �� ElementName$ WTWindow��6  �� 5(   
   $��Event Bewerken��6   ���#00b4d8$��2��6@   $��4��6M   
���   �$��3q�6q   $��5q�6�   $
��Auto��6�   ��6�   �� *CloseWindowCommandWTEdit+$ OneWay=���6�   �� $ WTWindow��6�   �� 5)   
   $��Event Verwijderen��6   ���#00b4d8$��3��6C   $��4��6P   
���   �$��3q�6t   $��5q�6�   $
��Auto��6�   $��Verwijderen��6�   ��6�   �� 6�   �� 5*   
   
������$��6��6I   $��4��6V   $��30(�6j   $��5,5,5,10q�6x   $
��Auto��6�   $��Center=�6�   $
��1039��6�   ��6   �� *Foutmelding+6�   �� 5,   
   $��
Characters��6   ���#023e8a
�������$��0��6P   $��0��6]   
���   �$��3q�6�   $
��Auto��6  $��Center=�6  ��6�   �� *CloseWindowCommandChar+$ OneWay=���6�   �� $ WTWindow��6  �� 5-   
   $��Affiliations��6   ���#023e8a
�������$��0��6Q   $��1��6^   
���   �$��3q�6�   $
��Auto��6  $��Center=�6  ��6�   �� *CloseWindowCommandAff+$ OneWay=���6�   �� $ WTWindow��6  �� 5.   
   $
��Arcs��6   $��0��6!   ���#023e8a
�������$��2��6V   
���   �$��3q�6z   $
��Auto��6�   $��Center=�6  ��6�   �� *CloseWindowCommandArc+$ OneWay=���6�   �� $ WTWindow��6  �� 5/   
   $��Places��6   $��0��6#   ���#023e8a
�������$��3��6X   
���   �$��3q�6|   $
��Auto��6�   $��Center=�6
  ��6�   �� *CloseWindowCommandPlace+$ OneWay=���6�   �� $ WTWindow��6
  �� 50   
   $��World Timeline��6   ���#00b4d8
�������$��0��6T   $��4��6a   
���   �$��3q�6�   $
��Auto��6  $��Center=�6  ��6�   �� *CloseWindowCommandWT+$ OneWay=���6�   �� $ WTWindow��6  52      53      