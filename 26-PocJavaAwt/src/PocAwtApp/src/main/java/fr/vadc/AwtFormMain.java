package fr.vadc;

import java.awt.*;
import java.awt.event.*;
import java.awt.event.WindowListener;

class AwtFormMain extends Frame {

    // initializing using constructor
    AwtFormMain() {

        // creating a button
        Button b = new Button("Click Me!!");

        // setting button position on screen
        b.setBounds(30, 100, 80, 30);

        // adding button into frame
        add(b);

        // frame size 300 width and 300 height
        setSize(300, 300);

        // setting the title of Frame
        setTitle("This is our basic AWT example");

        // no layout manager
        setLayout(null);

        // Important part to close window when click on X button
        addWindowListener(new WindowAdapter() {
            public void windowClosing(WindowEvent e) {
                dispose();
            }
        });
        // now frame will be visible, by default it is not visible
        setVisible(true);
    }
}
