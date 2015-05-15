import java.io.BufferedWriter;
import java.io.File;
import java.io.FileWriter;
import java.io.IOException;
import java.util.Random;


public class GenerateurHotelInsert {

	public static String generateurInsert() {
		String[] listeNom = {"Andalouse","Colombe","Saada","El Houna","Piwe","Bosphore","Azur Turk","Calypso","Mogador", "Paris" , 
				"Londre", "Alger", "Oran", "St Rock", "AZUR", "Turk", "Saada", "Ennour","El ouard", "Errajaa", "El amir", 
				"Les sables d'or", "Mazafran", "Sheraton", "Hilton", "St Georges", "El Djazayer", "Aeroport", "El matar", "Soltan", 
				"Pan", "El assad", "Azure Blue", "Midétéranée", "Le front de mer", "L'espadon", "Le bon vieu temps", "Djurjura", 
				"Atlas", "Tikejda", "Hogar", "Didouch", "Dey", "La casbah", "Jugurta", "El amin", "El aman", "El farah", "Touat", "Saoura"};

		String[] ville = {"Oran", "Alger", "Ghardaia", "Bejaia", "Constantine", "Batna"};
		Random random = new Random();
		StringBuilder insertReq = new StringBuilder();
		
		insertReq.append("USE [HotelsDB]\n");
        insertReq.append("GO\n");
        for (int i=1; i < 1000; i++ ) {
        	int index1 = random.nextInt(16);
    		int index2 = random.nextInt(16);
		insertReq.append("INSERT INTO [dbo].[Hotels] ("
				+ "[Name]"
				+ ",[Description]"
				+ ",[NbStars]"
				+ ",[PhoneNumber1]"
				+ " ,[FaxNumber1]"
				+ ",[Email1]"
				+ ",[Address]"
				+ ",[Town]"
				+ ",[Wilaya])");
		insertReq.append(" VALUES "
				+ " ( 'Hotel "+listeNom[index1]+" "+listeNom[index2]+"'"		
				+ ",'Hotel de ........'"
				+ ",'"+random.nextInt(5)+"'"
				+ ",'0"+random.nextInt(999999999)+"'"
		        + ",'0"+random.nextInt(999999999)+"'"
		        + ",'"+listeNom[index1]+listeNom[index2]+"@mail.dz'"
		        + ",'"+random.nextInt(999)+" rue "+listeNom[random.nextInt(16)]+"'"
		        + ",'"+ville[random.nextInt(4)]+"'"
		        + ",'"+ville[random.nextInt(4)]+"'"
				+")\n");
        }
		insertReq.append("GO");
		
		return insertReq.toString();
	}
	
	public static void main(String[] args) throws IOException{
		File file = new File("insertHotel.sql");
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

