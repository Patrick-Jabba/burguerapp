import { shallowMount } from "@vue/test-utils";
import Home from "@/views/Home.vue";
import router from "@/router";

const wrapper = shallowMount(Home, {
  global: {
    plugins: [router],
  },
});

describe("<Home />", () => {
  it("should render home correctly", async () => {
    router.push("/");
    await router.isReady();

    expect(wrapper.html()).toMatchSnapshot();
  });

  it("should find a div with a class main-container", async () => {
    expect(wrapper.get(".main-container"));
  });

  test("throws on octopus", () => {
    expect(() => {
      wrapper.get(".does-not-exist-class");
    }).toThrow();
  });

  it("should catch an error after does not find an nonexistent class div", async () => {
    const t = () => {
      throw new TypeError();
    };
    expect(t).toThrow(TypeError);
  });
});
