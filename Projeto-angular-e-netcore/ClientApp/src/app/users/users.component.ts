import { Component, OnInit } from '@angular/core';
import { UserDataService } from '../_data-services/user.data-service';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  users: any[] = [];
  user: any = {};
  userLogin: any = {};
  userLogged: any = {};
  showList: boolean = true;
  isAuthenticated: boolean = false;

  constructor(private userDataService: UserDataService) { }

  ngOnInit() {
    
  }

  get() {
    this.userDataService.get().subscribe((data: Object) => {
      this.users = data as any[];
      this.showList = true;
    }, error => {
      console.log(error);
      alert('erro interno do sistema');
    })
  }

  put() {
    this.userDataService.put(this.user).subscribe(data => {
      if (data) {
        alert('Usuario alterado com sucesso');
        this.get();
        this.user = {};
      }
      else {
        alert('Erro ao alterar usuário');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema - PUT');
    });
  }
  post() {
    this.userDataService.post(this.user).subscribe(data => {
      if (data) {
        alert('Usuario cadastrado com sucesso');        
        this.get();
        this.user = {};
      }
      else {
        alert('Erro ao cadastrar usuário');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema - POST');
    });
  }
  save() {
    if (this.user.id) {
      this.put();
    } else {
      this.post();
    }
  }
  edit(user:any) {
    this.user = user;
    this.showList = false;
  }

  delete(user: any) {
    this.userDataService.delete(user.id).subscribe(data => {
      if (data) {
        alert('Usuario removido com sucesso');
        this.get();
        this.user = {};
      }
      else {
        alert('Erro ao remover usuário');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema - DELETE');
    });
  }

  authenticate() {
      this.userDataService.authenticate(this.userLogin).subscribe((data:any) => {
      if (data.user) {
        localStorage.setItem('user_logged', JSON.stringify(data));
        this.isAuthenticated = true;
        this.get();
        this.getUserData();
      }
      else {
        alert('Erro ao autenticar usuário');
      }
    }, error => {
      console.log(error);
      alert('erro interno do sistema - Authenticate');
    });
  }
  getUserData() {
    const userLoggedString = localStorage.getItem('user_logged');
    if (userLoggedString !== null) {
      this.userLogged = JSON.parse(userLoggedString);
    }
    this.isAuthenticated = this.userLogged != null;
  }

}


interface IUser {
  name: string;
  email: string;
}
