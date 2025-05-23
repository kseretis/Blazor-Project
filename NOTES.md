# Σημειώσεις


## Βάση Δεδομένων
Για τη σύνδεση και χρήση της βάσης δεδομένων Microsoft SQL Server χρησιμοποιήθηκε ένα docker image. 
Για να τρέξει η εφαρμογή και να εμφανιστούν τα δεδομένα πρέπει να εκτελεστεί η εντολή

```
docker compose up -d
```
Αφού τρέξει η εφαρμογή να εκτελεστεί η παρακάτω εντολή για την ενημέρωση και εισαγωγή dummy δεδομένων στην βάση δεδομένων.

```
dotnet ef database update
```

Για τη σύνδεση της βάσης δεδομένων με την εφαρμογή χρησιμοποιήθηκε connection string το οποίο τοποθετήθηκε σε αρχείο ***secrets.json***, όπως και για κάποιες άλλες τιμές. Για λόγους ευκολίας το τοποθετώ εδώ. Μπορεί να τοποθετηθεί στο τέλος του αρχείου ***appsettings.json*** ή στο αρχείο ***appsettings.Development.json***. 

```
{
  "ConnectionStrings:DefaultConnection": "Server=localhost,1433;Initial Catalog=blazorAppDb;User ID=sa;Password=YourStrongPassword123;TrustServerCertificate=True",
  "TokenService": {
    "ClientId": "blazor-app",
    "ClientSecret": "secret",
    "Scope": "api"
  }
}
```

## Εφαρμογή

Δημιουργήθηκαν 3 καινούργια pages τα οποία και εμφανίζονται αριστερά στο menu (2 από τα 3).
- Το πρώτο ***(Customers)*** εμφανίζει το Grid με τους πελάτες, υπάρχουν οι επιλογές αναζήτησης, φίλτρα και ταξινόμηση. Με κλίκ στην γραμμή ανοίγει ένα Modal ***(UpdateCustomerModal)*** με τα στοιχεία του πελάτη για την τροποίηση τους. Στα δεξία κάθε γραμμής υπάρχει ένα εικονίδιο για την διαγραφή του πελάτη.
- Στο δεύτερο ***(NewCustomer)*** υπάρχει η φόρμα για την προσθήκη νέου πελάτη. Έχουν εφαρμοτεί validations για την υποχρεωτικότητα μερικών πεδίων.

Στις παραπάνω σελίδες χρησιμοποιούνται όλες οι CRUD λειτουργίες.

Σε όλο τον κώδικα υπάρχουν σχόλια για καλύτερη κατανόηση.

`/customers`

![img.png](img.png)

`updatecustomermodal`

![img_1.png](img_1.png)

`/newcustomer`

![img_2.png](img_2.png)

## Duende IdentityServer

Για την ασφάλεια της εφαρμογής χρησιμοποιήθηκε το ****Duende IdentityServer****. Έχει γίνει setup στην backend εφαρμογή. Το API είναι προστατευμένο και χρειάζεται authentication.
Στο αρχείο ***DuendeConfig.cs*** δημιουργήθηκε ένας Client και ένα ApiScope, για να μπορέσει να συνδεθεί η εφαρμογή με το IdentityServer. Σε επίπεδο frontend μια κλήση HTTP λαμβάνεται το access token και τοποθετείται ως Authentication Key στο Header των HTTP κλήσεων στο API για τη λήψη, επεξεργασία και διαγραφή δεδομένων από τη βάση. **Δεν είναι ο ασφαλέστερος τρόπος, ούτε ο πιο αποδοτικός, ούτε αυτός που θα επέλεγα σε καμία περίπτωση. Απλώς δημιουργήθηκε για να δείξει ότι η εφαρμογή είναι ασφαλής και ότι οι κλήσεις γίνονται με το access token.**

## Employee & Manager

Σχετικά με το πρόβλημα **Employee & Manager**, δημιουργήθηκαν 3 λύσεις και βρίσκονται στα αρχεία ***Solution1.cs***, ***Solution2.cs*** και ***Solution3.cs***, στο BlazorApp.Client/EmployeeAndManager.
Στην κλάση ***CallSolutions.cs*** υπάρχουν οι κλήσεις των 3 λύσεων και η εκτύπωση των αποτελεσμάτων στην κονσόλα.

## Επεκτάσεις

- Δημιουργία Test project
- Δημιουργία Unit Tests & Integration Tests
- Mock τη βάση δεδομένων και δημιουργία tests στο επίπεδο repository για να βεβαιωθούμε ότι οι κλήσεις προς τη βάση είναι ορθές.
- Mock του repository και δημιουργία tests στο επίπεδο service για να βεβαιωθούμε ότι οι κλήσεις προς το repository είναι ορθές.
- Mock του service και δημιουργία tests στο επίπεδο controller για να βεβαιωθούμε ότι οι κλήσεις προς το service γυρνάν αποτελέσματα ή αποτυγχάνουν.
- Mock του controller και δημιουργία tests για να βεβαιωθούμε ότι οι κλήσεις προς το controller στα endpoints γυρνάν αποτελέσματα ή αποτυγχάνουν.