import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Random;


public class GenerateurFeaturesInsert {
	
		public static String generateurInsert() {
			String[] listeFeature = {"WIFI","Parking","Cafeteria","Restorant","TV","Sonat","Petit dejeuner", "Reveil", "Laverie"};
			Random random = new Random();
			StringBuilder insertReq = new StringBuilder();
			
			insertReq.append("USE [HotelsDB]\n");
	        insertReq.append("GO\n");
	        for (int i=0; i < 9; i++ ) {
			insertReq.append("INSERT INTO [dbo].[Features] ("
					+ "[FeatureName])"
					);
			insertReq.append(" VALUES "
					+ " ( '"+listeFeature[i]+"'"		
					+")\n");
	        }
			insertReq.append("GO");
			
			return insertReq.toString();

		}
		
		public static void main(String[] args) throws IOException{
			File file = new File("insertFeatures.sql");
			if(file.exists()) {
				file.delete();
			}
			System.out.println(file.getAbsolutePath());
			file.createNewFile();
			BufferedWriter bWriter = new BufferedWriter(new FileWriter(file));
			bWriter.write(generateurInsert());
			bWriter.close();
		}

}
