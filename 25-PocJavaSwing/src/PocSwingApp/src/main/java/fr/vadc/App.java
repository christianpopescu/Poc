package fr.vadc;

import java.awt.*;
import java.awt.event.*;
import javax.swing.*;

/**
 * Hello world!
 */
public class App {
    public static void main(String[] args) {
         EventQueue.invokeLater(() ->
		{
		var frame = new SimpleFrame();
		frame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		frame.setVisible(true);
		});
	 }
}


class SimpleFrame extends JFrame
{
private static final int DEFAULT_WIDTH = 300;
private static final int DEFAULT_HEIGHT = 200;

private JLabel label = new JLabel();
private JPanel panel = new JPanel();
public SimpleFrame()
{
	setSize(DEFAULT_WIDTH, DEFAULT_HEIGHT);
	addWindowListener(new WindowAdapter( ) {
public void windowClosing(WindowEvent e) {
System.exit(0);
}
});
	label.setText("Hello World!");
	panel.add(label);
	add(panel);
}
}