package com.goatsoft.unfuckwam;

import java.io.*;
import javax.imageio.ImageIO;
import java.awt.Component;
import javax.swing.filechooser.FileFilter;
import javax.swing.JFileChooser;
import java.awt.image.BufferedImage;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.List;
import java.util.stream.Collectors;
import java.util.stream.Stream;
import javax.swing.JFrame;

public class Main extends JFrame
{
    public String WamFolder = "..\\EdnaCore\\Content\\map";
    public String OutFolder = "..\\EdnaCore\\Content\\map_converted";

    public static void main(final String[] args) throws IOException {
        new Main();
    }

    public Main() throws IOException {
        try (Stream<Path> walk = Files.walk(Paths.get(WamFolder))) {

            List<String> result = walk.filter(Files::isRegularFile)
                    .map(x -> x.toString()).filter(f -> f.endsWith(".wam")).collect(Collectors.toList());

            for (String fileEntry : result
                 ) {
                File f = new File(fileEntry);
                String newName = f.getName() + "c";

                UnfuckWam(f);

                System.out.println("#begin map_converted/" + newName + "\n" +
                        "/copy:map_converted/" + newName + "\n");
            }

        } catch (IOException e) {
            e.printStackTrace();
        }
    }

    private void UnfuckWam(File wamFile)
    {
        try{
            final FileInputStream fis = new FileInputStream(wamFile);
            final ObjectInputStream stream = new ObjectInputStream(fis);
            boolean[][] wamArrays = (boolean[][])stream.readObject();

            int wamSize = 800 * 600;
            byte[] wamBytes = new byte[wamSize];
            int wamAt = 0;

            for (int x = 0; x < 800; ++x) {
                for (int y = 0; y < 600; ++y) {
                    wamBytes[wamAt] = wamArrays[x][y] ? (byte) 1 : (byte) 0;
                    wamAt++;
                }
            }

            FileOutputStream fos = new FileOutputStream(OutFolder + "\\" + wamFile.getName() + "c");
            fos.write(wamBytes);
            fos.close();

            stream.close();
            fis.close();
        }
        catch (FileNotFoundException e) {
            e.printStackTrace();
        }
        catch (IOException e2) {
            e2.printStackTrace();
        }
        catch (ClassNotFoundException e3) {
            e3.printStackTrace();
        }


    }

    private BufferedImage getBufferedImageFromFile(final String dialogTitle) throws IOException {
        final JFileChooser myJFileChooser = new JFileChooser();
        myJFileChooser.setFileFilter(new FileFilter() {
            @Override
            public boolean accept(final File myFile) {
                return myFile.isDirectory() || myFile.getName().toLowerCase().endsWith(".gif");
            }

            @Override
            public String getDescription() {
                return "*.gif";
            }
        });
        myJFileChooser.setDialogTitle(dialogTitle);
        final int returnVal = myJFileChooser.showOpenDialog(null);
        if (returnVal == 0) {
            return ImageIO.read(myJFileChooser.getSelectedFile());
        }
        return null;
    }

    public ObjectOutputStream getObjectOutputStreamIntoFile(final String dialogTitle) throws IOException {
        final String postFix = ".wam";
        final JFileChooser myJFileChooser = new JFileChooser();
        myJFileChooser.setDialogType(1);
        myJFileChooser.setFileFilter(new FileFilter() {
            @Override
            public boolean accept(final File myFile) {
                return myFile.isDirectory() || myFile.getName().toLowerCase().endsWith(".wam");
            }

            @Override
            public String getDescription() {
                return "*.wam";
            }
        });
        myJFileChooser.setDialogTitle(dialogTitle);
        final int returnVal = myJFileChooser.showSaveDialog(null);
        if (returnVal == 0) {
            File myFile = myJFileChooser.getSelectedFile();
            if (!myFile.getName().toLowerCase().endsWith(".wam")) {
                myFile = new File(String.valueOf(myFile.getAbsolutePath()) + ".wam");
            }
            return new ObjectOutputStream(new FileOutputStream(myFile));
        }
        return null;
    }
}
