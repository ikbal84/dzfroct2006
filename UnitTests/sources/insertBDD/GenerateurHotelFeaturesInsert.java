import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Random;


public class GenerateurHotelFeaturesInsert {
	
	public static String generateurInsert() {
		Random random = new Random();
		StringBuilder insertReq = new StringBuilder();
		
		insertReq.append("USE [HotelsDB]\n");
        insertReq.append("GO\n");
        for (int i=0; i < 50; i++ ) {
		insertReq.append("INSERT INTO [dbo].[HotelFeatures] ("
				+ " [Price]"
                + ",[Feature_FeatureID]"
                + ",[Hotel_HotelID])"
				);
		insertReq.append(" VALUES "
				+ " ( '"+random.nextInt(3000)+"'"
				+ ",'"+random.nextInt(9)+"'"
				+ ",'"+random.nextInt(30)+"'"
				+")\n");
        }
		insertReq.append("GO");
		
		return insertReq.toString();

	}
	
	public static void main(String[] args) throws IOException{
		File file = new File("insertHotelFeatures.sql");
		if(file.exists()) {
			file.delete();
		}
		file.createNewFile();
		BufferedWriter bWriter = new BufferedWriter(new FileWriter(file));
		bWriter.write(generateurInsert());
		bWriter.close();
	}

}
