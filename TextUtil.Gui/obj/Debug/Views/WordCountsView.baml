   M S B A M L   `   `   `  ����  TextUtil.Gui'    !TextUtil.Gui.Views.WordCountsView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � RowDefinitions  5	   
   �� 5
      $��25 �6   �� 5      $	��200 �6   �� 5      $��50 �6   �� 5      $��50 �6   �� 5      $��25 �6   �� 5      $��* �6   .+�5   
   �� $��0��6   $��Enter text:��6   �� 5   
   $��1��6   $��	10,5,10,5q�6    �� TextWrapping$
 Wrap=�6H    �� AcceptsReturn . " �� VerticalScrollBarVisibility$ Visible=�6q   ��62   �� *Text+6q   �� 5   
   $��2��6   .+�5      �� 
 �� Top$ 7��6   $��Text parsing strategy:��6#   �� 5       �� Left$	 137��6   $ 12��6)   $	��262��6\   ��69   �� *
Strategies+ �� SelectedValue 6h   �� *
Strategy+ �� Mode$ TwoWay=�5      �� 5   
   $��3��6   $	��362��6   $��30��6*   $��Get Word Counts��66   ��6P   ��  �� Path$ GetWordCountsCommand��� 5   
   $��4��6   ��6"   �� $ WordCounts.Count�	 �� StringFormat$	 Total distinct words: {0}���� 5   
   $��5��6   ��6    �� *
WordCounts+
 �� View
 5      �� 5      P�5      �� 5       �� Width$	 100��6)   $
��Word��65    �� DisplayMemberBinding 6C   �� *Word+�� 5      $	 100��6)   $��Occurances Count��65    6O   �� *Count+5!      5#      5%      5&      