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
    this.get();
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
}


interface IUser {
  name: string;
  email: string;
}
