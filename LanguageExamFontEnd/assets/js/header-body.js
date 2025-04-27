class HeaderComponent extends HTMLElement {
    connectedCallback() {
      this.innerHTML = `
        
      `;
    }
  }
  
  customElements.define('header-body-component', HeaderComponent);
  