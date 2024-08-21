import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class MesasLocalService {

  // fbMesasColID = "Mesas";
  // constructor(
  //   private firestore: AngularFirestore,
  //   private storage: AngularFireStorage
  //   ) { }

  // getMesasByArea(area: string) {
  //   return this.firestore
  //   .collection(this.fbMesasColID,
  //              ref => ref.where("area", "==", area)
  //   ).valueChanges({'idField': 'id'});
  // }

  // updateMesa(mesa: any) {
  //   return this.firestore
  //   .collection(this.fbMesasColID)
  //   .doc(mesa.id).update(mesa);
  // }
  // uploadMesaImagenRef(nombre:string) {
  //   return this.storage.ref(nombre);
  // }
  // uploadMesaImagen(nombre:string, data: any) {

  //   return this.storage.upload(nombre, data);
  // }

}
